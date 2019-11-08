using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Packaging;
using System.IO;
using System.Data;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;

namespace Cnit.Testor.Core.Packaging
{
    public sealed class TestManager
    {
        private DataPackageManager _manager;
        private string _fileFormatVersion = "2.0";
        private CompressionOption _testCompression;

        internal TestManager(DataPackageManager manager)
        {
            _manager = manager;
            _testCompression = CompressionOption.Normal;
        }

		public void TestVersion()
		{
			Uri versionUri = new Uri("/version.dat", UriKind.Relative);
			if (_manager.CurrentPackage.PartExists(versionUri))
			{
				PackagePart versionPart = _manager.CurrentPackage.GetPart(versionUri);
				using (StreamReader sr = new StreamReader(versionPart.GetStream()))
				{
					string ver = sr.ReadToEnd();
					string[] version = ver.Split(new string[] { ":", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
					if (version.Length >= 2)
					{
						if (new Version(version[1]).Major < new Version(_fileFormatVersion).Major)
							throw new VersionNotFoundException(String.Format("Не поддерживаемая версия файла: {0}\nПоддерживаемая версия: {1}", version[1], _fileFormatVersion));
					}
				}
			}
		}

        public void SaveTestorData(TestorData testorData, TestConfig config)
        {
            testorData.AcceptChanges();
            Dictionary<string, string> testKeys = new Dictionary<string, string>();
            Dictionary<string, string> questCounts = new Dictionary<string, string>();
            foreach (TestorData.CoreTestsRow test in testorData.CoreTests)
            {
                testKeys.Add(test.TestKey.ToString(), test.TestName);
                questCounts.Add(test.TestKey.ToString(),
                    testorData.CoreQuestions.Where(c => c.TestId == test.TestId).Count().ToString());
            }
            PackagePart dataPart;
            PackagePart configPart;
            bool createNew = true;
            Guid fname = Guid.NewGuid();
            Uri partUri = new Uri(
                String.Format("/tests/{0}.bin", fname.ToString()), UriKind.Relative);
            Uri configUri = new Uri(
                String.Format("/tests/{0}.conf", fname.ToString()), UriKind.Relative);
            List<Uri> parts = new List<Uri>();
            foreach (var rel in _manager.CurrentPackage.GetRelationships())
                if (testKeys.Keys.Contains(rel.RelationshipType)
                    && !parts.Contains(rel.TargetUri))
                    parts.Add(rel.TargetUri);
            if (parts.Count == 1)
            {
                createNew = false;
                configUri = _manager.GetConfigUri(parts[0]);
                partUri = parts[0];
            }
            else if (parts.Count > 1)
                throw new Exception("Невозможно сохранить тесты в разных parts.");
            if (createNew)
            {
                dataPart = _manager.CurrentPackage.CreatePart(partUri,
                   _manager.CnitType + ContentType.Test.ToString(), _testCompression);
                configPart = _manager.CurrentPackage.CreatePart(configUri,
                   _manager.CnitType + ContentType.TestConfig.ToString(), _testCompression);
                foreach (var id in testKeys)
                {
                    config.Uri = partUri;
                    config.TestName = id.Value;
                    config.QuestionCount = int.Parse(questCounts[id.Key]);
                    _manager.CurrentPackage.CreateRelationship(partUri, TargetMode.Internal, id.Key);
                }
            }
            else
            {
                dataPart = _manager.CurrentPackage.GetPart(partUri);
                configPart = _manager.CurrentPackage.GetPart(configUri);
                Dictionary<string, TestConfig> testObjects = GetTestObjects(partUri);
                foreach (var key in testKeys)
                {
                    if (!testObjects.ContainsKey(key.Key))
                    {
                        _manager.CurrentPackage.CreateRelationship(partUri, TargetMode.Internal,key.Key);
                    }
                    config.Uri = partUri;
                    config.TestName = key.Value;
                    config.QuestionCount = int.Parse(questCounts[key.Key]);
                }
            }
			Uri versionUri = new Uri("/version.dat", UriKind.Relative);
			if (!_manager.CurrentPackage.PartExists(versionUri))
			{
				_manager.CurrentPackage.CreatePart(versionUri, _manager.CnitType + ContentType.VersionData.ToString());
				PackagePart versionPart = _manager.CurrentPackage.GetPart(versionUri);
				using (Stream versionStream = versionPart.GetStream())
				{
					StreamWriter sw = new StreamWriter(versionStream);
                    sw.WriteLine("FileFormatVersion:{0}",_fileFormatVersion);
					sw.Close();
					versionStream.Close();
				}
			}
            BinaryFormatter bin = new BinaryFormatter();
            using (Stream stream = dataPart.GetStream())
            {
                bin.Serialize(stream, testorData);
                stream.Close();
            }
            using (Stream stream = configPart.GetStream())
            {
                bin.Serialize(stream, config);
                stream.Close();
            }
        }

        public Dictionary<string, TestConfig> GetTestObjects()
        {
            return GetTestObjects(null);
        }

        public Dictionary<string, TestConfig> GetTestObjects(Uri partUri)
        {
            Dictionary<string, TestConfig> retValue = new Dictionary<string, TestConfig>();
            IEnumerable rels;
            if (partUri == null)
                rels = _manager.CurrentPackage.GetRelationships();
            else
                rels = _manager.CurrentPackage.GetRelationships().Where(c => c.TargetUri == partUri);
            foreach (PackageRelationship rel in rels)
            {
                if (_manager.CurrentPackage.GetPart(rel.TargetUri).ContentType == _manager.CnitType + ContentType.Test.ToString())
                {
                    TestConfig config = new TestConfig();
                    Uri uri = _manager.GetConfigUri(rel.TargetUri);
                    PackagePart configPart = _manager.CurrentPackage.GetPart(uri);
                    using (Stream stream = configPart.GetStream())
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        config = (TestConfig)bin.Deserialize(stream);
                        stream.Close();
                    }
                    retValue.Add(rel.RelationshipType, config);
                }
            }
            return retValue;
        }

        public TestorData GetTestData(Uri uri)
        {
            TestorData dataSet = new TestorData();
            PackagePart part = _manager.CurrentPackage.GetPart(uri);
            using (Stream stream = part.GetStream())
            {
                BinaryFormatter bin = new BinaryFormatter();
                dataSet=(TestorData)bin.Deserialize(stream);
                stream.Close();
            }
            return dataSet;
        }

        public TestorData[] GetAllTestData()
        {
            List<TestorData> retValue = new List<TestorData>();
            foreach (var part in _manager.GetParts(ContentType.Test))
                using (Stream stream = part.GetStream())
                {
                    TestorData dataSet = new TestorData();
                    dataSet.ReadXml(stream);
                    stream.Close();
                    retValue.Add(dataSet);
                }
            return retValue.ToArray();
        }
    }
}

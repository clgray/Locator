using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Packaging;
using System.IO;
using System.Data;
using Cnit.Testor.Core.Packaging;
using System.Collections;

namespace Cnit.Testor.Core.Packaging
{
    public sealed class DataPackageManager
    {
        private const string _cnittype = "cnit-testorcore/";
        private TestManager _testManager;
        private string _fileName;
        private Package _package;

        internal Package CurrentPackage
        {
            get
            {
                return _package;
            }
        }

        public bool IsPackageOpen
        {
            get
            {
                return !(_package == null);
            }
        }


        public string CnitType
        {
            get
            {
                return _cnittype;
            }
        }

        public TestManager TestManager
        {
            get
            {
                return _testManager;
            }
        }

        public DataPackageManager(string fileName)
        {
            _fileName = fileName;
            _testManager = new TestManager(this);
        }

        public void Open()
        {
            if (_package == null)
            {
                _package = Package.Open(_fileName);
                _testManager.TestVersion();
            }
        }

        public void Close()
        {
            _package.Close();
            _package = null;
        }

        public IEnumerable<PackagePart> GetParts(ContentType type)
        {
            return _package.GetParts().Where(c => c.ContentType == _cnittype + type.ToString());
        }

        public Uri GetConfigUri(Uri uri)
        {
            return new Uri(String.Format("{0}.conf",
                        uri.ToString().Replace(".bin", String.Empty)), UriKind.Relative);
        }

        public void DeletePart(Uri part)
        {
            var rels = _package.GetRelationships();
            List<string> relIds = new List<string>();
            foreach (var rel in rels.Where(c => c.TargetUri == part))
                relIds.Add(rel.Id);
            foreach(var relId in relIds)
                _package.DeleteRelationship(relId);
            _package.DeletePart(part);
            Uri confUri = GetConfigUri(part);
            if(_package.PartExists(confUri))
                _package.DeletePart(confUri);
        }
    }
}

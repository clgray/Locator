using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Cnit.Testor.Core.Packaging
{
    public sealed class TestHelper
    {
        private TestConfig _config;
        private TestorData _testorData;
        private DataPackageManager _manager;
        private ListViewItem _currentItem;

        public event EventHandler HelperUpdated;

        public TestConfig TestConfig
        {
            get
            {
                return _config;
            }
            set
            {
                _config = value;
            }
        }

        public bool IsMasterTest
        {
            get
            {
                return _config.IsMasterTest;
            }
            set
            {
                _config.IsMasterTest = value;
            }
        }

        public string FullFileName
        {
            get
            {
                return _config.FileName;
            }
            set
            {
                _config.FileName = value;
                OnHelperUpdated();
            }
        }

        public string FileName
        {
            get
            {
                return new FileInfo(_config.FileName).Name;
            }
        }

        public int TestId
        {
            get
            {
                return _config.TestId;
            }
            set
            {
                _config.TestId = value;
            }
        }

        public Uri Uri
        {
            get
            {
                return _config.Uri;
            }
            set
            {
                _config.Uri = value;
            }
        }


        public DateTime ConvTime
        {
            get
            {
                return _config.ConvTime;
            }
            set
            {
                _config.ConvTime = value;
            }
        }

        public ListViewItem ListViewItem
        {
            get
            {
                return _currentItem;
            }
            set
            {
                _currentItem = value;
            }
        }

        public TestorData TestorData
        {
            get
            {
                if (_testorData == null)
                {
                    bool needClose = false;
                    if (!_manager.IsPackageOpen)
                    {
                        _manager.Open();
                        needClose = true;
                    }
                    _testorData = _manager.TestManager.GetTestData(_config.Uri);
                    if (needClose)
                        _manager.Close();
                }
                return _testorData;
            }
            set
            {
                _testorData = value;
            }
        }

        public bool IsTestorDataLoaded
        {

            get
            {
                return !(_testorData == null);
            }
        }

        public string TestName
        {
            get
            {
                return _config.TestName;
            }
            set
            {
                if (_config.TestName != value)
                {
                    if (value.Length == 0)
                        _config.TestName = "Без имени";
                    else
                        _config.TestName = value;
                    OnHelperUpdated();
                }
            }
        }

        public List<string> TestRequirements
        {
            get
            {
                return _config.TestRequirements;
            }
            set
            {
                _config.TestRequirements = value;
            }
        }

        public int QuestCount
        {
            get
            {
                return _config.QuestionCount;
            }
            set
            {
                _config.QuestionCount = value;
                OnHelperUpdated();
            }
        }

        public string TestKey
        {
            get
            {
                return _config.TestKey;
            }
            set
            {
                _config.TestKey = value;
            }
        }

        public Dictionary<string, int> SubTests
        {
            get
            {
                return _config.SubTests;
            }
            set
            {
                _config.SubTests = value;
            }
        }

        public TestHelper(DataPackageManager manager)
        {
            _manager = manager;
            _config = new TestConfig();
        }

        public TestHelper(DataPackageManager manager,TestConfig config)
        {
            _manager = manager;
            _config = config;
        }

        public void OnHelperUpdated()
        {
            if (HelperUpdated != null)
                HelperUpdated(this, new EventArgs());
        }

        public override string ToString()
        {
            return _config.TestName;
        }
    }
}

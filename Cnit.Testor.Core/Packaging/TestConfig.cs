using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cnit.Testor.Core.Packaging
{
    [Serializable]
    public class TestConfig
    {
        private Uri _uri;
        private bool _isMasterTest;
        private string _testName;
        private string _fileName;
        private int _questionCount;
        private string _testKey;
        private DateTime _convTime;
        private List<string> _testReq;
        private int _testId;
        private Dictionary<string,int> _subTests;

        public Uri Uri
        {
            get
            {
                return _uri;
            }
            set
            {
                _uri = value;
            }
        }

        public int TestId
        {
            get
            {
                return _testId;
            }
            set
            {
                _testId = value;
            }
        }

        public bool IsMasterTest
        {
            get
            {
                return _isMasterTest;
            }
            set
            {
                _isMasterTest = value;
            }
        }

        public string TestName
        {
            get
            {
                return _testName;
            }
            set
            {
                _testName = value;
            }
        }

        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
            }
        }

        public int QuestionCount
        {
            get
            {
                return _questionCount;
            }
            set
            {
                _questionCount = value;
            }
        }

        public string TestKey
        {
            get
            {
                return _testKey;
            }
            set
            {
                _testKey = value;
            }
        }

        public DateTime ConvTime
        {
            get
            {
                return _convTime;
            }
            set
            {
                _convTime = value;
            }
        }

        public List<string> TestRequirements
        {
            get
            {
                return _testReq;
            }
            set
            {
                _testReq = value;
            }
        }

        public Dictionary<string, int> SubTests
        {
            get
            {
                return _subTests;
            }
            set
            {
                _subTests = value;
            }
        }

        public TestConfig()
        {
            _testReq = new List<string>();
            _subTests = new Dictionary<string, int>();
        }
    }
}

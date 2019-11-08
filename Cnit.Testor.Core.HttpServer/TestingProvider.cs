using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnit.Testor.Core.Server;

namespace Cnit.Testor.Core.HttpServer
{
    [Serializable]
    public abstract class TestingProvider
    {
        protected List<int> _questIds = new List<int>();
        protected List<int> _ansIds = new List<int>();
        protected double _score;
        protected int _index = -1;
        protected HttpHandler _handler;
        protected string[] _requestUriParts;
        protected Dictionary<string, List<string>> _requestParams;
        protected HtmlStore _currentQuestion;
        protected ProviderState _state;
        protected TestorData _testorData;
        protected CoreTestRowAdapter _coreTest;
        protected DateTime _testStartTime;
        protected EndSessionResult _testEndResult;
        protected ProviderMode _providerMode = ProviderMode.LocalMode;
        protected string _notActiveMessage;
        protected TestorTreeItem[] _requirementsTests;
        protected string _warningMessage;
        protected bool _showSecurityAlert;
        protected string _secondComputerAddress = String.Empty;
        protected int _additionalTime;

        public event EventHandler<EventArgs> ScoreChanged;
        public event EventHandler<EventArgs> StateChanged;
        public event EventHandler<EventArgs> WarningMessage;
        public event EventHandler<EventArgs> TimeChanged;

        public int AdditionalTime
        {
            get
            {
                return _additionalTime;
            }
            set
            {
                _additionalTime = value;
            }
        }

        public bool ShowSecurityAlert
        {
            get
            {
                return _showSecurityAlert;
            }
        }

        public string SecondComputerAddress
        {
            get
            {
                return _secondComputerAddress;
            }
        }

        public ProviderMode ProviderMode
        {
            get
            {
                return _providerMode;
            }
            set
            {
                _providerMode = value;
            }
        }

        public string WarningMessageContent
        {
            get
            {
                return _warningMessage;
            }
        }

        public TestorTreeItem[] RequirementsTests
        {
            get
            {
                return _requirementsTests;
            }
        }

        public string NotActiveMessage
        {
            get
            {
                return _notActiveMessage;
            }
        }

        public int CurrentQuestId
        {
            get
            {
                return _questIds[_index];
            }
        }

        public HtmlStore CurrentQuestion
        {
            get
            {
                return _currentQuestion;
            }
        }

        public ProviderState State
        {
            get
            {
                return _state;
            }
            protected set
            {
                if (_state != value)
                {
                    _state = value;
                    OnStateChanged();
                }
            }
        }

        public virtual bool IsTestActive
        {
            get
            {
                if (!_coreTest.IsActive)
                    _notActiveMessage = "Тест не активен";
                return _coreTest.IsActive;
            }
        }

        public string TestName
        {
            get
            {
                return _coreTest.TestName.Trim();
            }
        }

        public int TimeLimit
        {
            get
            {
                int retValue = _coreTest.TimeLimit;
                if (retValue != 0)
                {
                    retValue += _additionalTime;
                }
                return retValue;
            }
        }

        public bool ShowRightAnswersCount
        {
            get
            {
                return _coreTest.ShowRightAnswersCount;
            }
        }

        public bool ShowTestResult
        {
            get
            {
                return _coreTest.ShowTestResult;
            }
        }

        public double PassingScore
        {
            get
            {
                return _coreTest.PassingScore;
            }
        }

        public int PassagesNumber
        {
            get
            {
                return _coreTest.PassagesNumber;
            }
        }

        public string Description
        {
            get
            {
                return _coreTest.Description;
            }
        }

        public DateTime BeginTime
        {
            get
            {
                return _coreTest.BeginTime;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return _coreTest.EndTime;
            }
        }

        public bool AllowAdmitQuestions
        {
            get
            {
                return _coreTest.AllowAdmitQuestions;
            }
        }

        public DateTime TestStartTime
        {
            get
            {
                return _testStartTime;
            }
        }

        public int CurrentQuestNumber
        {
            get
            {
                return _index + 1;
            }
        }


        public double Score
        {
            get
            {
                return _score;
            }
        }


        public DateTime TestEndTime
        {
            get
            {
                if (_testEndResult == null || _testEndResult.EndTime == DateTime.MinValue)
                    return DateTime.Now;
                return _testEndResult.EndTime;
            }
        }

        public EndSessionResult EndSessionResult
        {
            get
            {
                return _testEndResult;
            }
        }

        public int AnsQuestCount
        {
            get
            {
                return _ansIds.Count;
            }
        }

        public virtual TimeSpan RemaningTime
        {
            get
            {
                TimeSpan retValue = TimeSpan.FromSeconds(0);
                if (TimeLimit != 0)
                    retValue = TestStartTime.AddMinutes(TimeLimit + AdditionalTime) - DateTime.Now;
                return retValue;
            }
            set { }
        }

        public abstract int QuestCount { get; }
        public abstract double MaxScore { get; }
        public abstract bool ShowDetailsTestResult { get; }
        public abstract string StudentDisplayName { get; }
        public abstract string UniqId { get; }

        public void UnsubscribeWarningMessage()
        {
            WarningMessage = null;
        }

        public abstract string GetAppealHtml(int sessionId);

        public string GetAppealHtml()
        {
            if (ShowDetailsTestResult)
            {
                return GetAppealHtml(EndSessionResult.SessionId);
            }
            else
                return String.Empty;
        }

        public Response ProcessReuqest(string[] requestUriParts,
            Dictionary<string, List<string>> requestParams)
        {
            _showSecurityAlert = TestSecurityAlert();
            _warningMessage = String.Empty;
            Response retValue = new Response();
            _handler = new HttpHandler(this);
            _requestUriParts = requestUriParts;
            _requestParams = requestParams;
            int questId = -1;
            bool isNewQuestion = true;
            if (requestParams.ContainsKey("questid") && requestParams["questid"].Count > 0)
                int.TryParse(requestParams["questid"][0], out questId);
            if (requestUriParts.Length >= 2 && requestUriParts[1] == "images")
            {
                if (requestUriParts.Length < 2)
                    return null;
                byte[] image = _handler.GetImage(requestUriParts[2]);
                retValue.ResponseType = "image/png";
                retValue.ResponseArr = image;
                return retValue;
            }
            else if (requestUriParts.Length >= 2 && requestUriParts[1] == "answer")
            {
                if (_providerMode != ProviderMode.WebMode)
                {
                    if (!requestParams.ContainsKey("hid") || requestParams["hid"].Count == 0)
                        return null;
                    if (!String.IsNullOrEmpty(TestingHttpServer.Hid) && requestParams["hid"][0] != TestingHttpServer.Hid)
                        return null;
                    TestingHttpServer.Hid = String.Empty;
                }
                if (requestParams.Where(c => c.Key.StartsWith("tcv_") && c.Value.Count > 0
                    && !String.IsNullOrEmpty(c.Value[0].Trim())).Count() != 0)
                {
                    bool isOk = ProcessAnswer(questId, ref _warningMessage);
                    if (!isOk)
                    {
                        isNewQuestion = false;
                        OnWarningMessage(_warningMessage);

                    }
                }
                else
                    isNewQuestion = false;
            }
            else if (requestUriParts.Length >= 2 && requestUriParts[1].ToLower() == "start")
            {
                if (State == ProviderState.PreTesting)
                    StartTest();
            }
            else if (requestUriParts.Length >= 2 && requestUriParts[1].ToLower() == "endtest")
            {
                if (State == ProviderState.Testing)
                    EndTest();
            }

            if (State == ProviderState.Testing)
                ProcessQuestion(isNewQuestion);
            string html = String.Empty;
            retValue.ResponseType = "text/html";
            if (State == ProviderState.PreTesting)
                html = _handler.GetPreTestingHtml();
            else if (State == ProviderState.Testing)
                html = _handler.GetQuestionHtml();
            else if (State == ProviderState.Results)
                html = _handler.GetResultsHtml();
            retValue.ResponseValue = html;
            return retValue;
        }

        public void SetQuestId(int questId)
        {
            int index = 0;
            foreach (var quest in _questIds)
            {
                if (quest == questId)
                    break;
                index++;
            }
            _index = index;
        }

        public virtual void OnScoreChanged()
        {
            if (ScoreChanged != null)
                ScoreChanged(this, new EventArgs());
        }

        public virtual void OnStateChanged()
        {
            if (StateChanged != null)
                StateChanged(this, new EventArgs());
        }

        public virtual void OnWarningMessage(string message)
        {
            if (WarningMessage != null)
                WarningMessage(message, new EventArgs());
            _warningMessage = message;
        }

        public virtual void OnTimeChanged()
        {
            if (TimeChanged != null)
                TimeChanged(this, new EventArgs());
        }

        internal abstract bool ProcessAnswer(int questId, ref string message);
        internal abstract void ProcessQuestion(bool isNewQuestion);
        public abstract void StartTest();
        public abstract void EndTest();
        public abstract bool TestSecurityAlert();
    }
}

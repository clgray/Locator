using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core.Packaging;

namespace Cnit.Testor.Core.HttpServer.TestingProviders
{
    [Serializable]
    public sealed class RemoteTestingProvider : TestingProvider
    {
        private TestorTreeItem _selectedTest;
        private StartTestParams _startParams;
        private IServerProvider _webServerProvider;
        private bool? _isTestActive;
        private bool _useCompression;
        private string _currentUniqId;

        public string CurrentUniqId
        {
            get
            {
                return _currentUniqId;
            }
            set
            {
                _currentUniqId = value;
            }
        }

        public ITestEdit TestEdit
        {
            get
            {
                if (_webServerProvider == null)
                    return StaticServerProvider.TestEdit;
                else
                    return _webServerProvider.TestEdit;
            }
        }

        public ITestClient TestClient
        {
            get
            {
                if (_webServerProvider == null)
                    return StaticServerProvider.TestClient;
                else
                    return _webServerProvider.TestClient;
            }
        }

        public IUserManagement UserManagement
        {
            get
            {
                if (_webServerProvider == null)
                    return StaticServerProvider.UserManagement;
                else
                    return _webServerProvider.UserManagement;
            }
        }

        public IHelperService HelperService
        {
            get
            {
                if (_webServerProvider == null)
                    return StaticServerProvider.HelperService;
                else
                    return _webServerProvider.HelperService;
            }
        }

        public TestorCoreUser CurrentUser
        {
            get
            {
                if (_webServerProvider == null)
                    return StaticServerProvider.CurrentUser;
                else
                    return _webServerProvider.HelperService.GetServerVersion(TestingSystem.ProtocolVersionString);
            }
        }

        public override int QuestCount
        {
            get
            {
                if (_startParams == null)
                    return _coreTest.QuestionsNumber;
                else
                    return _startParams.QuestIds.Count();
            }
        }

        public override double MaxScore
        {
            get
            {
                return _startParams.MaxScore;
            }
        }

        public override bool ShowDetailsTestResult
        {
            get
            {
                return _coreTest.ShowDetailsTestResult;
            }
        }

        public override bool IsTestActive
        {
            get
            {
                if (!_isTestActive.HasValue)
                {
                    if (!_coreTest.IsActive || (_coreTest.BeginTime != DateTime.MinValue && _coreTest.BeginTime > DateTime.Now) ||
                       (_coreTest.EndTime != DateTime.MinValue && _coreTest.EndTime < DateTime.Now))
                    {
                        _notActiveMessage = "Тест не активен";
                        return false;
                    }
                    else if (!TestClient.IsPassagesNumberNotOverlimit(_coreTest.TestId))
                    {
                        _notActiveMessage = "Превышено максимальное количество попыток прохождения теста";
                        _isTestActive = false;
                        return _isTestActive.Value;
                    }
                    else
                    {
                        TestorTreeItem[] req = TestClient.GetCurrentUserFailRequirements(_coreTest.TestId);
                        if (req.Count() > 0)
                        {
                            _notActiveMessage = "Перед прохлждением данного теста необходимо пройти предыдущие тесты";
                            _isTestActive = false;
                            _requirementsTests = req;
                            return _isTestActive.Value;
                        }
                    }
                    _isTestActive = true;
                    return _isTestActive.Value;
                }
                else
                    return _isTestActive.Value;
            }
        }

        public override string StudentDisplayName
        {
            get
            {
                var currentUser = CurrentUser;
                string retValue = String.Format("{0} {1} {2}", HtmlStore.GetString(currentUser.LastName),
                  HtmlStore.GetString(currentUser.FirstName), HtmlStore.GetString(currentUser.SecondName));
                if (String.IsNullOrEmpty(retValue.Trim()))
                    return "Анонимный пользователь";
                else
                    return retValue;
            }
        }

        public override TimeSpan RemaningTime
        {
            get
            {
                return _startParams.RemaningTime + TimeSpan.FromMinutes(AdditionalTime);
            }
            set
            {
                _startParams.RemaningTime = value - TimeSpan.FromMinutes(AdditionalTime);
            }
        }

        public override string UniqId
        {
            get { return _startParams.UniqId; }
        }

        private void InitNextId(int x)
        {
            if (x == _questIds.Count)
            {
                EndTest();
                return;
            }
            _index++;
            x++;
            if (_index >= _questIds.Count)
                _index = 0;
            if (_ansIds.Contains(_questIds[_index]))
                InitNextId(x);
        }

        internal override void ProcessQuestion(bool isNewQuestion)
        {
            if (_webServerProvider == null)
            {
                StartTestParams startParams = StaticServerProvider.TestClient.GetNotCommitedSessions(0, false);
                if (startParams != null && startParams.AdditionalTime.HasValue)
                {
                    AdditionalTime = startParams.AdditionalTime.Value;
                    OnTimeChanged();
                }
            }

            if (isNewQuestion)
                InitNextId(0);
            if (State == ProviderState.Results)
                return;
            int qId = _questIds[_index];
            try
            {
                bool getBlobs = _webServerProvider == null;
                if (_useCompression)
                    _currentQuestion = HtmlStore.GetHtmlStore(DataCompressor.DecompressData<TestorData>(TestClient.GetQuestion(qId, getBlobs)), qId);
                else
                    _currentQuestion = HtmlStore.GetHtmlStore(TestClient.GetQuestionData(qId, getBlobs), qId);
            }
            catch (TimeoutException)
            {
                _currentQuestion = null;
            }
            catch
            {
                State = ProviderState.Results;
            }
        }

        internal override bool ProcessAnswer(int questId, ref string message)
        {
            if (!_questIds.Contains(questId))
                return false;
            QuestAnswerResult result = TestClient.ProcessAnswer(questId, _requestParams);
            message = result.Message;
            if (!result.isRightAnswer.HasValue)
                return false;
            if (result.isRightAnswer.Value)
                _score += result.Score;
            _ansIds.Add(questId);
            OnScoreChanged();
            return true;
        }

        public override void StartTest()
        {
            _startParams = TestClient.StartTest(_selectedTest.TestId.Value);
            InitStartParams();
            _currentUniqId = _startParams.UniqId;
        }

        private void InitStartParams()
        {
            _testStartTime = _startParams.StartTime;
            _questIds.AddRange(_startParams.QuestIds);
            State = ProviderState.Testing;
        }

        public override void EndTest()
        {
            _testEndResult = TestClient.EndSession();
            State = ProviderState.Results;
        }

        public RemoteTestingProvider(IServerProvider webServerProvider, TestorTreeItem selectedTest, TestorData testorData, StartTestParams startParams, bool useCompression)
        {
            _webServerProvider = webServerProvider;
            _selectedTest = selectedTest;
            _testorData = testorData;
            _coreTest = CoreTestRowAdapter.GetAdapter(_testorData.CoreTests[0]);
            _useCompression = useCompression;
            _startParams = startParams;
            if (_startParams != null)
            {
                InitStartParams();
                _ansIds.AddRange(_startParams.AnsIds);
                _score = _startParams.CurrentScore;
            }
            else
                State = ProviderState.PreTesting;
        }

        public override string GetAppealHtml(int sessionId)
        {
            return TestClient.GetAppealHtml(sessionId);
        }

        public override bool TestSecurityAlert()
        {
            TestorSecurityAlertResult alResult = null;
            if (_webServerProvider == null)
                alResult = StaticServerProvider.TestClient.SetSecurityAlert(_currentUniqId);
            else
                alResult = _webServerProvider.TestClient.SetSecurityAlert(_currentUniqId);
            _secondComputerAddress = alResult.UniqId;
            return alResult.ShowAlert;
        }
    }
}

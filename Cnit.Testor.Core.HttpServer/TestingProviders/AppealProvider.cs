using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnit.Testor.Core.Server;

namespace Cnit.Testor.Core.HttpServer.TestingProviders
{
    public sealed class AppealProvider: TestingProvider
    {
        private TestSessionStatistics _statistics;
        private IServerProvider _webServerProvider;

        private ITestClient TestClient
        {
            get
            {
                if (_webServerProvider == null)
                    return StaticServerProvider.TestClient;
                else
                    return _webServerProvider.TestClient;
            }
        }

        public override int QuestCount
        {
            get
            {
                return _questIds.Count;
            }
        }

        public override double MaxScore
        {
            get { throw new NotImplementedException(); }
        }

        public override bool ShowDetailsTestResult
        {
            get
            {
                return true;
            }
        }

        public override string StudentDisplayName
        {
            get { throw new NotImplementedException(); }
        }

        public override string UniqId
        {
            get { return string.Empty; }
        }


        internal override bool ProcessAnswer(int questId, ref string message)
        {
            throw new NotImplementedException();
        }

        internal override void ProcessQuestion(bool isNewQuestion)
        {
            if (isNewQuestion)
            {
                if (_index == _questIds.Count - 1)
                    _index = -1;
                _index++;
            }
            try
            {
                int qId = _questIds[_index];
                AppealResult appeal = TestClient.GetQuestionAppeal(_statistics.TestSessionId, qId, true);
                var htmlStore = HtmlStore.GetHtmlStore(appeal.TestorData, qId);
                htmlStore.IsAppeal = true;
                htmlStore.AppealIsRight = appeal.IsRightAnswer;
                htmlStore.Answer = appeal.Answer;
                _currentQuestion = htmlStore;
            }
            catch (Exception ex)
            {
                SystemMessage.ShowErrorMessage(ex);
            }
        }

        public override void StartTest()
        {
            throw new NotImplementedException();
        }

        public override void EndTest()
        {
            throw new NotImplementedException();
        }

        public AppealProvider(TestSessionStatistics statistics, int[] questIds, IServerProvider webServerProvider)
        {
            _webServerProvider = webServerProvider;
            _questIds.AddRange(questIds);
            _statistics = statistics;
            State = ProviderState.Testing;
        }

        public void GoBack()
        {
            _index--;
            if (_index < 0)
                _index = _questIds.Count - 1;
            _index--;
            if (_index < 0)
                _index = _questIds.Count - 1;
        }

        public override string GetAppealHtml(int sessionId)
        {
            return TestClient.GetAppealHtml(sessionId);
        }

        public override bool TestSecurityAlert()
        {
            return false;
        }
    }
}

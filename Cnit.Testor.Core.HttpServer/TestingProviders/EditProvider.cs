using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core.HttpServer.QuestionsProviders;

namespace Cnit.Testor.Core.HttpServer.TestingProviders
{
    public sealed class EditProvider : TestingProvider
    {
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
        {}

        public override void StartTest()
        {
            throw new NotImplementedException();
        }

        public override void EndTest()
        {
            throw new NotImplementedException();
        }

        public EditProvider(HtmlStore quest)
        {
            _currentQuestion = quest;
            State = ProviderState.Testing;
        }

        public override string GetAppealHtml(int sessionId)
        {
            return String.Empty;
        }

        public override bool TestSecurityAlert()
        {
            return false;
        }

        public void SetHtmlStore(HtmlStore quest)
        {
            _currentQuestion = quest;
        }
    }
}

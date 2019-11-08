using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnit.Testor.Core.Packaging;
using Cnit.Testor.Core.HttpServer.QuestionsProviders;
using Cnit.Testor.Core.Server;

namespace Cnit.Testor.Core.HttpServer.TestingProviders
{
	public sealed class LocalTestingProvider : TestingProvider
	{
		private int _questCount;
		private TestHelper _testHelper;

		private string _studentName;

		public override int QuestCount
		{
			get
			{
				return _questCount;
			}
		}

		public override double MaxScore
		{
			get
			{
				return _testorData.CoreQuestions.Where(
					c => _questIds.Contains(c.QuestionId)).Sum(c => c.QuestionMark);
			}
		}

        public override bool ShowDetailsTestResult
        {
            get
            {
                return _coreTest.ShowDetailsTestResult; 
            }
        }

		public override string StudentDisplayName
		{
			get
			{
				if (_studentName.Length > 50)
					return _studentName.Substring(0, 49) + "...";
				return _studentName;
			}
		}

        public override string UniqId
        {
            get { return string.Empty; }
        }

		public LocalTestingProvider(TestorData tests, TestHelper testHelper)
		{
			_studentName = "Иванов Иван Иванович";
			State = ProviderState.PreTesting;
			_testHelper = testHelper;
			_testorData = tests;
            _coreTest = CoreTestRowAdapter.GetAdapter(testHelper.TestorData.CoreTests.Where(
				c => c.TestKey == new Guid(testHelper.TestKey)).First());
			if (!_testHelper.IsMasterTest)
			{
				if (_coreTest.QuestionsNumber != 0)
					_questCount = _coreTest.QuestionsNumber;
				else
					_questCount = _testHelper.QuestCount;
			}
			else
			{
				_questCount = 0;
				foreach (var quest in _testHelper.SubTests)
					_questCount += quest.Value;
			}
		}

		public override void StartTest()
		{
			if (!IsTestActive)
				return;
			if (_testHelper.IsMasterTest)
				foreach (var subTest in _testHelper.SubTests)
					GetQuestsFromTest(subTest.Key, subTest.Value);
			else
				GetQuestsFromTest(_coreTest.TestKey.ToString(), _questCount);
			_questIds = _questIds.OrderBy(c => Guid.NewGuid()).ToList();
			_testStartTime = DateTime.Now;
			State = ProviderState.Testing;
		}

		private void GetQuestsFromTest(string test, int count)
		{
			Guid testx = new Guid(test);
			int testId = _testorData.CoreTests.Where(c => c.TestKey == testx).First().TestId;
			var quests = (from x in _testorData.CoreQuestions
						  where x.TestId == testId
						  select new
						  {
							  QuestGuid = Guid.NewGuid(),
							  QuestId = x.QuestionId
						  }).OrderBy(c => c.QuestGuid).Take(count);
			foreach (var quest in quests)
				_questIds.Add(quest.QuestId);
		}

        public override void EndTest()
        {
            _testEndResult = new EndSessionResult()
            {
                EndTime = DateTime.Now,
                SessionId = 0
            };
            State = ProviderState.Results;
        }

		internal override bool ProcessAnswer(int questId, ref string message)
		{
			if (_questIds.Contains(questId))
				_ansIds.Add(questId);
			else
				return false;
			if (_currentQuestion.QuestIndex != questId)
				return false;
			BaseQuestionProvider qp = QuestionsHtmlFactory.GetQuestionProvider(_currentQuestion);
            string answer = null;
            bool? isRightAnswer = qp.IsRightAnswer(_requestParams, ref message, ref answer);
			if (!isRightAnswer.HasValue)
				return false;
			double mark = 0;
			if (isRightAnswer.Value)
			{
				mark = _testorData.CoreQuestions.Where(c => c.QuestionId == questId).FirstOrDefault().QuestionMark;
				_score += mark;
			}
			OnScoreChanged();
			return true;
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
			if (isNewQuestion)
				InitNextId(0);
			if (State == ProviderState.Results)
				return;
			int qId = _questIds[_index];
			_currentQuestion = HtmlStore.GetHtmlStore(_testorData, qId);
		}

		public void SetStudentName(string studentName)
		{
			_studentName = studentName;
		}

        public override string GetAppealHtml(int sessionId)
        {
            return String.Empty;
        }

        public override bool TestSecurityAlert()
        {
            return false;
        }
    }
}

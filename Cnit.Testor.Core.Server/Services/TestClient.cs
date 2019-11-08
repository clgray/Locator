using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Reflection;
using Cnit.Testor.Core.HttpServer.QuestionsProviders;
using System.Diagnostics;
using Cnit.Testor.Core.Packaging;
using System.Data.Linq;
using Cnit.Testor.Core.HttpServer.TestingProviders;
using System.Data.SqlClient;
using System.Data;

namespace Cnit.Testor.Core.Server.Services
{
	[Serializable]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, AddressFilterMode = AddressFilterMode.Any)]
	public sealed class TestClient : TestorServiceBase, ITestClient
	{
		public StartTestParams StartTest(int testId)
		{
			Debug.Assert(testId > 0);

			StartTestParams retValue = new StartTestParams();
			using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
			{
				var test = dataContext.CoreTests.Where(c => c.TestId == testId).First();
				if (!test.IsActive || test.IsDeleted)
					throw new Exception("Тест не активен");
				if ((test.BeginTime > DateTime.Now && test.BeginTime != DateTime.MinValue)
				|| (test.EndTime < DateTime.Now && test.EndTime != DateTime.MinValue))
					throw new Exception("Тест не активен");
				int count = dataContext.TestSessions.Where(c => c.TestId == testId && c.UserId == Provider.CurrentUser.UserId).Count();
				if (test.PassagesNumber != 0 && count >= test.PassagesNumber)
					throw new Exception("Превышено максимальное количество попыток");
				if (GetCurrentUserFailRequirements(testId).Count() > 0)
					throw new Exception("Предварительные тесты не пройдены");
				TestSession newSession = new TestSession();
				newSession.UserId = Provider.CurrentUser.UserId;
				newSession.TestId = test.TestId;
				newSession.Score = -1;
				newSession.IsPassed = false;

				List<TestSessionQuestion> sessionQuests = new List<TestSessionQuestion>();
				if (test.IsMasterTest)
				{
					var masterParts = dataContext.CoreMasterParts.Where(c => c.MasterTestId == test.TestId).ToArray();
					foreach (var masterPart in masterParts)
						sessionQuests.AddRange(GetQuestsFromTest(newSession, null, masterPart, dataContext));
				}
				else
					sessionQuests.AddRange(GetQuestsFromTest(newSession, test, null, dataContext));

				short i = 0;
				if (test.IsMasterTest && test.VariantsMode)
				{
					foreach (var quest in sessionQuests.OrderBy(c => Guid.NewGuid()))
					{
						quest.QuestionIndex = i;
						dataContext.TestSessionQuestions.InsertOnSubmit(quest);
						i++;
					}
				}
				else
				{
					foreach (var quest in sessionQuests)
					{
						quest.QuestionIndex = i;
						dataContext.TestSessionQuestions.InsertOnSubmit(quest);
						i++;
					}
				}

				newSession.UniqId = Guid.NewGuid().ToString().Substring(0, 5);
				newSession.ClientIP = Provider.ClientIP;
				dataContext.TestSessions.InsertOnSubmit(newSession);
				newSession.StartTime = DateTime.Now;
				dataContext.SubmitChanges();
				InitStartTestParams(newSession, retValue, test.TimeLimit * 60, false, dataContext);
				newSession.MaxScore = retValue.MaxScore;
				dataContext.SubmitChanges();
			}
			return retValue;
		}

		public StartTestParams GetNotCommitedSessions(int userId, bool getLastSession)
		{
			StartTestParams retValue = new StartTestParams();
			using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
			{
				if (userId <= 0)
				{
					if (Provider.CurrentUser == null)
						return null;
					userId = Provider.CurrentUser.UserId;
				}
				TestSession session = null;
				if (!getLastSession)
				{
					session = dataContext.TestSessions.Where(x => x.UserId == userId && x.EndTime == null).FirstOrDefault();
					if (session == null)
						return null;
				}
				else
					session = dataContext.TestSessions.Where(x => x.UserId == userId).OrderByDescending(c => c.EndTime).First();

				int timeLimit = session.CoreTest.TimeLimit * 60;
				retValue.AdditionalTime = session.AdditionalTime;

				if (timeLimit != 0 && session.AdditionalTime.HasValue)
					timeLimit += session.AdditionalTime.Value * 60;

				InitStartTestParams(session, retValue, timeLimit, true, dataContext);
				if (timeLimit > 0 && (DateTime.Now - session.StartTime).TotalSeconds >= timeLimit)
				{
					EndSession(session, dataContext);
					if (!getLastSession)
						return null;
					else
						return retValue;
				}
			}
			return retValue;
		}

		//Не является операцией сервиса
		private void InitStartTestParams(TestSession newSession, StartTestParams retValue, int timeLimit, bool isResume,
			DataClassesTestorCoreDataContext dataContext)
		{
			retValue.StartTime = newSession.StartTime;
			var questIds = from c in newSession.TestSessionQuestions
						   orderby c.QuestionIndex
						   select new
						   {
							   QuestId = c.QuestionId,
							   Mark = c.CoreQuestion.QuestionMark,
							   IsRightAnswer = c.IsRightAnswer
						   };
			List<int> listIds = new List<int>();
			List<int> ansIds = new List<int>();
			double maxScore = 0;
			foreach (var quest in questIds)
			{
				listIds.Add(quest.QuestId);
				if (quest.IsRightAnswer != null)
					ansIds.Add(quest.QuestId);
				maxScore += quest.Mark;
			}
			retValue.TestId = newSession.TestId;
			retValue.QuestIds = listIds.ToArray();
			retValue.AnsIds = ansIds.ToArray();
			retValue.MaxScore = maxScore;
			retValue.TestSettings = Helper.GetTestSettingsData(retValue.TestId);
			retValue.UniqId = newSession.UniqId;
			if (isResume)
				retValue.CurrentScore = GetScore(newSession, dataContext);
			else
				retValue.CurrentScore = 0;
			if (timeLimit > 0)
				retValue.RemaningTime = retValue.StartTime.AddSeconds(timeLimit) - DateTime.Now;
		}

		//Не является операцией сервиса
		private List<TestSessionQuestion> GetQuestsFromTest(TestSession session, CoreTest coreTest,
			CoreMasterPart masterPart, DataClassesTestorCoreDataContext dataContext)
		{
			Dictionary<Guid, int> realQuests = new Dictionary<Guid, int>();
			List<TestSessionQuestion> retValue = new List<TestSessionQuestion>();
			if (coreTest == null)
				coreTest = masterPart.CoreTest1;
			int count = 0;
			if (masterPart == null)
			{
				count = coreTest.QuestionsNumber;
				if (count == 0)
					count = coreTest.CoreQuestions.Count();
			}
			else
				count = masterPart.QuestionsNumber;
			if (count == 0)
				return new List<TestSessionQuestion>
				{
				};
			if (masterPart == null)
			{
				var quests = from x in dataContext.CoreQuestions
							 where x.TestId == coreTest.TestId
							 select x.QuestionId;
				foreach (var quest in quests)
					realQuests.Add(Guid.NewGuid(), quest);
			}
			else
			{
				var quests = from x in dataContext.CoreQuestions
							 where x.TestId == masterPart.PartTestId
							 select x.QuestionId;
				foreach (var quest in quests)
					realQuests.Add(Guid.NewGuid(), quest);
			}
			Random rnd = new Random((int)(DateTime.Now.TimeOfDay.TotalMilliseconds + DateTime.Now.TimeOfDay.TotalSeconds));
			var xq = realQuests.OrderBy(c => c.Key).OrderBy(c => rnd.Next(1, 1000)).Take(count);
			foreach (var quest in xq)
			{
				TestSessionQuestion newQuestion = new TestSessionQuestion();
				newQuestion.TestSession = session;
				newQuestion.QuestionId = quest.Value;
				retValue.Add(newQuestion);
			}
			return retValue;
		}

		//Не является операцией сервиса
		private TestorData GetQuestion(int questId, bool getRightAnswer, bool isAppeal, bool getBLOBs)
		{
			TestorData retValue = new TestorData();
			using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
			{
				if (!isAppeal)
				{
					if (QueriesUtility.IsQuestInSessionFunc(dataContext, Provider.CurrentUser.UserId, questId) <= 0)
						throw new Exception("Данный вопрос не входит в тест");
				}
				var questRow = retValue.CoreQuestions.NewCoreQuestionsRow();
				var quest = (from c in dataContext.CoreQuestions
							 where c.QuestionId == questId
							 select new
							 {
								 c.TestId,
								 c.QuestionType,
								 c.QuestionId,
								 c.Question,
								 c.QuestionMark
							 }).First();
				questRow.TestId = quest.TestId;
				questRow.QuestionType = quest.QuestionType;
				questRow.QuestionId = quest.QuestionId;
				questRow.Question = quest.Question;
				questRow.QuestionMark = quest.QuestionMark;
				questRow.QuestionMetadata = String.Empty;
				var questProvider = QuestionsHtmlFactory.GetQuestionProvider((QuestionType)quest.QuestionType, null);
				if (getRightAnswer || questProvider.SendAnswersToClient)
				{
					var answers = from c in dataContext.CoreAnswers
								  where c.QuestionId == quest.QuestionId
								  select new
								  {
									  c.Answer,
									  c.AnswerId,
									  c.IsTrue
								  };
					foreach (var answer in answers)
					{
						var answerRow = retValue.CoreAnswers.NewCoreAnswersRow();
						answerRow.Answer = answer.Answer;
						answerRow.AnswerId = answer.AnswerId;
						answerRow.AnswerMetadata = String.Empty;
						answerRow.QuestionId = questRow.QuestionId;
						if (getRightAnswer)
							answerRow.IsTrue = answer.IsTrue;
						else
							answerRow.IsTrue = false;
						retValue.CoreAnswers.AddCoreAnswersRow(answerRow);
					}
				}
				if (getBLOBs)
				{
					var blobs = from c in dataContext.CoreBLOBs
								where c.QuestionId == quest.QuestionId
								select new
								{
									c.BLOBId,
									c.BLOBContent
								};
					foreach (var blob in blobs)
					{
						var blobRow = retValue.CoreBLOBs.NewCoreBLOBsRow();
						blobRow.BLOBContent = blob.BLOBContent.ToArray();
						blobRow.BLOBId = blob.BLOBId;
						blobRow.QuestionId = questRow.QuestionId;
						retValue.CoreBLOBs.AddCoreBLOBsRow(blobRow);
					}
				}
				retValue.CoreQuestions.AddCoreQuestionsRow(questRow);
			}
			return retValue;
		}

		public TestorData GetQuestionData(int questId, bool getBLOBs)
		{
			Debug.Assert(questId > 0);

			return GetQuestion(questId, false, false, getBLOBs);
		}

		public byte[] GetQuestion(int questId, bool getBLOBs)
		{
			Debug.Assert(questId > 0);

			return DataCompressor.CompressData<TestorData>(GetQuestion(questId, false, false, getBLOBs));
		}

		public AppealResult GetQuestionAppeal(int sessionId, int questId, bool getBLOBs)
		{
			Debug.Assert(sessionId > 0);
			Debug.Assert(questId > 0);

			AppealResult retValue = new AppealResult();
			using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
			{
				var session = dataContext.TestSessions.Where(c => c.TestSessionId == sessionId).First();
				if (session.UserId != Provider.CurrentUser.UserId || session.CoreTest.ShowDetailsTestResult != true)
					Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);
				var quest = session.TestSessionQuestions.Where(c => c.QuestionId == questId).FirstOrDefault();
				if (quest == null)
					return null;
				retValue.TestorData = GetQuestion(questId, true, true, getBLOBs);
				retValue.Answer = quest.Answer;
				retValue.IsRightAnswer = quest.IsRightAnswer.HasValue ? quest.IsRightAnswer.Value : false;
			}
			return retValue;
		}

		public string GetAppealHtml(int sessionId)
		{
			StringBuilder retValue = new StringBuilder();
			int[] questIds;
			questIds = GetSessionQuestions(sessionId);
			TestSessionStatistics statistics = GetSessionStatistics(sessionId);
			SystemServerProvider systemProvider = new SystemServerProvider();
			AppealProvider provider = new AppealProvider(statistics, questIds, systemProvider);
			provider.ProviderMode = ProviderMode.WebMode;
			for (int i = 0; i < provider.QuestCount; i++)
			{
				var response = provider.ProcessReuqest(new string[] { }, new Dictionary<string, List<string>>());


				retValue.Append(String.Format("<b>Вопрос №{0} ({1})</b>", i + 1, !String.IsNullOrEmpty(provider.CurrentQuestion.Answer) ? (provider.CurrentQuestion.AppealIsRight ? "+" : "&ndash;") : "?"));
				retValue.Append("<table style=\"font-family:verdana,arial,sans-serif;border-right: #7177bb 1px solid; border-top: #7177bb 1px solid; border-left: #7177bb 1px solid;border-bottom: #7177bb 1px solid;\" width=\"100%\"><tr><td>"
					+ Encoding.UTF8.GetString(response.ResponseArr)
					+ "</td></tr></table><br/>");
			}
			return retValue.ToString();
		}

		public QuestAnswerResult ProcessAnswer(int questId, Dictionary<string, List<string>> requestParams)
		{
			Debug.Assert(questId > 0);

			QuestAnswerResult retValue = new QuestAnswerResult();

			using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
			{
				var session = (from c in dataContext.TestSessions
							   join x in dataContext.CoreTests on c.TestId equals x.TestId
							   where c.EndTime == null && c.UserId == Provider.CurrentUser.UserId
							   select new
							   {
								   x.TestId,
								   x.TimeLimit,
								   c.TestSessionId,
								   c.StartTime,
								   c.AdditionalTime
							   }).First();
				int timeLimit = session.TimeLimit;
				if (timeLimit != 0 && session.AdditionalTime.HasValue)
					timeLimit += session.AdditionalTime.Value;
				if (session.TimeLimit != 0 && (DateTime.Now - session.StartTime).TotalMinutes > timeLimit + 1)
					throw new Exception("Время истекло");
				TestorData testorData = GetQuestion(questId, true, false, false);
				HtmlStore currentQuestion = HtmlStore.GetHtmlStore(testorData, questId);
				BaseQuestionProvider qp = QuestionsHtmlFactory.GetQuestionProvider(currentQuestion);
				string message = null;
				string answer = null;
				retValue.isRightAnswer = qp.IsRightAnswer(requestParams, ref message, ref answer);
				retValue.Message = message;
				retValue.Score = 0;
				if (!retValue.isRightAnswer.HasValue)
					return retValue;
				if (retValue.isRightAnswer.Value)
					retValue.Score = testorData.CoreQuestions.Where(c => c.QuestionId == questId).FirstOrDefault().QuestionMark;
				var tsq = dataContext.TestSessionQuestions.Where(
					c => c.QuestionId == questId && c.TestSessionId == session.TestSessionId).First();
				tsq.IsRightAnswer = retValue.isRightAnswer;
				tsq.Answer = answer;
				dataContext.SubmitChanges();
			}
			return retValue;
		}

		public EndSessionResult EndSession()
		{
			EndSessionResult retValue = new EndSessionResult();

			using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
			{
				var session = dataContext.TestSessions.Where(x => x.UserId == Provider.CurrentUser.UserId && x.EndTime == null).FirstOrDefault();
				if (session == null)
				{
					var lastSession = dataContext.TestSessions.Where(x => x.UserId == Provider.CurrentUser.UserId).OrderByDescending(c => c.EndTime).First();
					if (!lastSession.EndTime.HasValue)
					{
						retValue.EndTime = DateTime.Now;
						retValue.SessionId = lastSession.TestSessionId;
						return retValue;
					}
					else
					{
						retValue.EndTime = lastSession.EndTime.Value;
						retValue.SessionId = lastSession.TestSessionId;
						return retValue;
					}
				}
				else
					return EndSession(session, dataContext);
			}
		}

		//Не является операцией сервиса
		private EndSessionResult EndSession(TestSession session, DataClassesTestorCoreDataContext dataContext)
		{
			Debug.Assert(session != null);

			EndSessionResult retValue = new EndSessionResult();

			session.EndTime = DateTime.Now;
			session.Score = GetScore(session, dataContext);
			double passingScore = session.CoreTest.PassingScore;
			if (passingScore != 0)
			{
				if (session.Score >= passingScore)
					session.IsPassed = true;
			}
			else
				session.IsPassed = true;
			dataContext.SubmitChanges();
			retValue.EndTime = session.EndTime.Value;
			retValue.SessionId = session.TestSessionId;
			return retValue;
		}

		//Не является операцией сервиса
		private short GetScore(TestSession session, DataClassesTestorCoreDataContext dataContext)
		{
			Debug.Assert(session != null);

			//dataContext.Log = new DebuggerWriter();
			var score = (from c in session.TestSessionQuestions
						 where c.IsRightAnswer == true
						 select new
						 {
							 QuestionMark = c.CoreQuestion.QuestionMark
						 }).Sum(c => c.QuestionMark);

			return (short)score;
		}

		public int AddAdditionalTime(short minutes, DateTime startTime, DateTime endTime,
			int groupId, int testId, int studentId)
		{
			int retValue = 0;
			using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
			{
				var stat = from c in dataContext.TestSessions
						   join u in dataContext.Users
						   on c.UserId equals u.UserId
						   where c.StartTime >= startTime && c.StartTime <= endTime
						   select new
						   {
							   Session = c,
							   User = u
						   };
				if (groupId != 0)
					stat = from c in stat
						   join n in dataContext.UserGroups
						   on c.User.UserId equals n.UserId
						   where n.GroupId == groupId
						   select c;
				if (testId != 0)
					stat = stat.Where(c => c.Session.TestId == testId);
				if (studentId != 0)
					stat = stat.Where(c => c.Session.UserId == studentId);
				var statistics = from x in stat
								 where x.Session.StartTime >= startTime && x.Session.StartTime <= endTime
								 && x.Session.EndTime == null
								 select x.Session;
				foreach (var ent in statistics)
				{
					if (ent.AdditionalTime == null)
						ent.AdditionalTime = minutes;
					else
						ent.AdditionalTime += minutes;
				}
				retValue = statistics.Count();
				dataContext.SubmitChanges();
			}
			return retValue;
		}

		public TestSessionStatistics[] GetStatistics(DateTime startTime, DateTime endTime,
			int groupId, int testId, int studentId)
		{
			if (startTime < new DateTime(2008, 1, 1))
				startTime = new DateTime(2008, 1, 1);

			if (endTime > new DateTime(3000, 1, 1) || endTime < startTime)
				endTime = new DateTime(3000, 1, 1);

			if (studentId != Provider.CurrentUser.UserId)
				Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

			TestSessionStatistics[] retValue = null;

			using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
			{
				var stat = from c in dataContext.TestSessions
						   join u in dataContext.Users
						   on c.UserId equals u.UserId
						   where c.StartTime >= startTime && c.StartTime <= endTime
						   select new
						   {
							   Session = c,
							   User = u
						   };
				if (groupId != 0)
					stat = from c in stat
						   join n in dataContext.UserGroups
						   on c.User.UserId equals n.UserId
						   where n.GroupId == groupId
						   select c;
				if (testId != 0)
					stat = stat.Where(c => c.Session.TestId == testId);
				if (studentId != 0)
					stat = stat.Where(c => c.Session.UserId == studentId);
				var statistics = from x in stat
								 where x.Session.StartTime >= startTime && x.Session.StartTime <= endTime
								 orderby x.User.LastName, x.User.FirstName, x.Session.StartTime descending
								 select new TestSessionStatistics()
								 {
									 RowNumber = 0,
									 TestSessionId = x.Session.TestSessionId,
									 Login = x.User.Login,
									 UserId = x.User.UserId,
									 TestId = x.Session.TestId,
									 FirstName = x.User.FirstName,
									 SecondName = x.User.SecondName,
									 LastName = x.User.LastName,
									 Score = x.Session.Score,
									 MaxScore = x.Session.MaxScore,
									 PassingScore = x.Session.CoreTest.PassingScore,
									 TestTime = x.Session.EndTime - x.Session.StartTime,
									 StartTime = x.Session.StartTime,
									 StudNumber = x.User.StudNumber,
									 GroupName = x.User.UserGroups.FirstOrDefault().GroupTrees.First().GroupName,
									 TestName = x.Session.CoreTest.TestName,
									 IsPassed = x.Session.IsPassed,
									 ShowTestResult = x.Session.CoreTest.ShowTestResult,
									 Percent = (x.Session.MaxScore != null && x.Session.MaxScore > 0) ? (x.Session.Score / x.Session.MaxScore) * 100 : 0
								 };

				retValue = statistics.ToArray();
				if (studentId == Provider.CurrentUser.UserId && (Provider.CurrentUser.UserRole != TestorUserRole.Administrator &&
					Provider.CurrentUser.UserRole != TestorUserRole.Teacher && Provider.CurrentUser.UserRole != TestorUserRole.Laboratorian))
				{
					foreach (var res in retValue.Where(c => !c.ShowTestResult))
					{
						res.Score = null;
						res.PassingScore = null;
						res.MaxScore = null;
						res.IsPassed = false;
					}
				}
			}
			int i = 1;
			foreach (var r in retValue)
			{
				r.RowNumber = i++;
			}
			return retValue;
		}

		public TestSessionStatistics GetSessionStatistics(int sessionId)
		{
			using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
			{
				var statistics = (from c in dataContext.TestSessions
								  join u in dataContext.Users
								  on c.UserId equals u.UserId
								  where c.TestSessionId == sessionId
								  select new TestSessionStatistics()
								  {
									  TestSessionId = c.TestSessionId,
									  Login = u.Login,
									  UserId = u.UserId,
									  TestId = c.TestId,
									  FirstName = u.FirstName,
									  SecondName = u.SecondName,
									  LastName = u.LastName,
									  Score = c.Score,
									  MaxScore = c.MaxScore,
									  PassingScore = c.CoreTest.PassingScore,
									  TestTime = c.EndTime - c.StartTime,
									  StartTime = c.StartTime,
									  StudNumber = u.StudNumber,
									  GroupName = u.UserGroups.FirstOrDefault().GroupTrees.First().GroupName,
									  TestName = c.CoreTest.TestName,
									  IsPassed = c.IsPassed,
									  ShowTestResult = c.CoreTest.ShowTestResult,
									  IPAddress = c.ClientIP
								  }).FirstOrDefault();
				if (statistics == null)
					return null;
				if (statistics.UserId != Provider.CurrentUser.UserId || statistics.ShowTestResult == false)
					Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);
				return statistics;
			}
		}

		public GetTestStatisticsResult GetTestStatistics(int testId, int groupId)
		{
			GetTestStatisticsResult retValue = new GetTestStatisticsResult();

			using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
			{
				var sessions = dataContext.TestSessions.Where(c => c.TestId == testId && c.Score >= 0);

				if (groupId != 0)
					sessions = from c in sessions
							   join n in dataContext.UserGroups
							   on c.UserId equals n.UserId
							   where n.GroupId == groupId
							   select c;

				retValue.AverageScore = sessions.Average(c => c.Score);
				int passed = sessions.Where(c => c.IsPassed == true).Count();
				if (passed != 0)
					retValue.PassedPercent = (sessions.Count() / passed) * 100;
				else
					retValue.PassedPercent = 0;

				var ts = from c in sessions
						 group c by c.Score into g
						 where g.Key.HasValue
						 orderby g.Key.Value
						 select new TestStatistics
						 {
							 Score = g.Key.Value,
							 ScoreCount = g.Count()
						 };

				retValue.TestStatistics = ts.ToArray();
			}

			return retValue;
		}

		public void ChangeSessionScore(int sessionId, double score)
		{
			Debug.Assert(sessionId > 0);
			Debug.Assert(score >= 0);

			Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

			using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
			{
				var currentSession = dataContext.TestSessions.Where(c => c.TestSessionId == sessionId).First();

				SystemEventsLog logMessage = new SystemEventsLog();
				logMessage.EventCode = (short)LogEventCodes.ChangeSessionScore;
				logMessage.EventTime = DateTime.Now;
				logMessage.Login = Provider.CurrentUser.Login;
				logMessage.EventText = String.Format("ChangeSessionScore. SessionId: {0}; UserId={1}; Score: {2}; NewScore: {3}",
					sessionId, currentSession.UserId, currentSession.Score, score);
				dataContext.SystemEventsLogs.InsertOnSubmit(logMessage);

				currentSession.Score = score;
				double passingScore = currentSession.CoreTest.PassingScore;
				if (passingScore != 0)
				{
					if (currentSession.Score >= passingScore)
						currentSession.IsPassed = true;
					else
						currentSession.IsPassed = false;
				}
				else
					currentSession.IsPassed = true;

				dataContext.SubmitChanges();
			}
		}

		public void DeleteSession(int sessionId)
		{
			Debug.Assert(sessionId > 0);

			Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

			using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
			{
				var testSession = dataContext.TestSessions.Where(c => c.TestSessionId == sessionId).First();

				SystemEventsLog logMessage = new SystemEventsLog();
				logMessage.EventCode = (short)LogEventCodes.SessionDeleted;
				logMessage.EventTime = DateTime.Now;
				logMessage.Login = Provider.CurrentUser.Login;
				logMessage.EventText = String.Format("Session deleted: UserId:{0};Score:{1};Test:{2}", testSession.UserId, testSession.Score, testSession.TestId);
				dataContext.SystemEventsLogs.InsertOnSubmit(logMessage);

				dataContext.TestSessionQuestions.DeleteAllOnSubmit(testSession.TestSessionQuestions);
				dataContext.TestSessions.DeleteOnSubmit(testSession);
				dataContext.SubmitChanges();
			}
		}

		public int[] GetSessionQuestions(int sessionId)
		{
			Debug.Assert(sessionId > 0);

			using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
			{
				//dataContext.Log = new DebuggerWriter();
				if (Provider.CurrentUser.UserRole == TestorUserRole.Administrator ||
				   Provider.CurrentUser.UserRole == TestorUserRole.Teacher ||
				   Provider.CurrentUser.UserRole == TestorUserRole.Laboratorian)
				{
					return (from c in dataContext.TestSessionQuestions
							where c.TestSessionId == sessionId
							select c.QuestionId).ToArray();
				}
				else if (Provider.CurrentUser.UserRole == TestorUserRole.Student)
				{
					return (from c in dataContext.TestSessionQuestions
							where c.TestSessionId == sessionId && c.TestSession.UserId == Provider.CurrentUser.UserId
							select c.QuestionId).ToArray();
				}
				else
					throw new Exception("Данные не найдены");
			}
		}

		public byte[] GetImage(string imageId)
		{
			Debug.Assert(!String.IsNullOrEmpty(imageId));

			byte[] retValue = null;

			using (SqlConnection conn = new SqlConnection(TestorSecurityProvider.ConnectionString))
			{
				SqlCommand command = new SqlCommand("SELECT BLOBContent FROM CoreBLOBs WHERE BLOBId=@BlobId", conn);
				command.Parameters.Add("@BlobId", SqlDbType.UniqueIdentifier).Value = new Guid(imageId);
				conn.Open();
				using (SqlDataReader rdr = command.ExecuteReader())
				{
					rdr.Read();
					retValue = rdr.GetSqlBinary(0).Value;
					rdr.Close();
				}
				conn.Close();
			}
			return retValue;
		}

		public TestorTreeItem[] GetCurrentUserFailRequirements(int testId)
		{
			Debug.Assert(testId > 0);

			TestorTreeItem[] retValue = null;

			using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
			{
				retValue = Helper.GetTestRequirements(testId);
				List<int> ids = new List<int>(retValue.Length);
				foreach (var r in retValue)
					ids.Add(r.TestId.Value);
				int userId = Provider.CurrentUser.UserId;
				var sessions = from c in dataContext.TestSessions
							   where ids.Contains(c.TestId) && c.UserId == userId && c.IsPassed == true
							   select c.TestId;
				var ses = sessions.Distinct().ToArray();
				retValue = retValue.Where(c => !ses.Contains(c.TestId.Value)).ToArray();
			}
			return retValue;
		}

		public bool IsPassagesNumberNotOverlimit(int testId)
		{
			Debug.Assert(testId > 0);

			bool retValue = false;

			using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
			{
				var passagesNumber = (from c in dataContext.CoreTests
									  where c.TestId == testId
									  select c.PassagesNumber).First();
				int count = dataContext.TestSessions.Where(c => c.TestId == testId && c.UserId == Provider.CurrentUser.UserId).Count();
				if (passagesNumber != 0 && count >= passagesNumber)
					retValue = false;
				else
					retValue = true;
			}

			return retValue;
		}

		public TestorTreeItem[] GetAppointedTests()
		{
			List<TestorTreeItem> retValue = new List<TestorTreeItem>();

			using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
			{
				var tests = dataContext.GetAppointedTests(Provider.CurrentUser.UserId);
				foreach (var test in tests.Where(c => c.PassedCount == 0))
				{
					TestorTreeItem newItem = new TestorTreeItem(test.NodeId, 0, test.TestName, TestorItemType.Test, new TestorTreeItem[] { });
					retValue.Add(newItem);
				}
			}
			return retValue.ToArray();
		}

		public string[] GetDatabaseNamesList()
		{
			using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
			{
				SystemEventsLog logMessage = new SystemEventsLog();
				logMessage.EventCode = (short)LogEventCodes.GetDatabaseNamesList;
				logMessage.EventTime = DateTime.Now;
				logMessage.Login = String.Empty;
				logMessage.EventText = "GetDatabaseNamesList";
				dataContext.SystemEventsLogs.InsertOnSubmit(logMessage);
				dataContext.SubmitChanges();

				Dictionary<string, string> databases = new Dictionary<string, string>();
				databases.Add("master", "JHU&*");
				databases.Add("model", "n98)I");
				databases.Add("msdb", "HBJhb&^g");
				databases.Add("tempdb", "0647EB-3C3FDCE7717A");
				databases.Add("ReportServer$SQLEXPRESS", "tsd;fk");
				databases.Add("ReportServer$SQLEXPRESSTempDB", "repoDfv#");
				databases.Add("Northwind", "adminadmin");
				databases.Add("testdb", "passwors;ldkasdfka;sd;SDKWPO^");
				databases.Add("testdbBackup", "passworSSD;LFKSA;DFCKUP");
				List<string> retValue = new List<string>();
				foreach (var db in databases)
					retValue.Add(db.Key);
				return retValue.ToArray();
			}
		}

		public string GetDatabasePassword(string databaseName)
		{
			Debug.Assert(!String.IsNullOrEmpty(databaseName));
			using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
			{
				SystemEventsLog logMessage = new SystemEventsLog();
				logMessage.EventCode = (short)LogEventCodes.GetDatabasePassword;
				logMessage.EventTime = DateTime.Now;
				logMessage.Login = String.Empty;
				logMessage.EventText = "GetDatabasePassword";
				dataContext.SystemEventsLogs.InsertOnSubmit(logMessage);
				dataContext.SubmitChanges();

				Dictionary<string, string> databases = new Dictionary<string, string>();
				databases.Add("master", "JHUIOPitr&*$*&gYIr%$%*()&*");
				databases.Add("model", "njpi[#EHpjkhnn98)I");
				databases.Add("msdb", "HBJhb&^gUIFf)&T()&*(");
				databases.Add("tempdb", "06478523-9316-465a-A2EB-3C3FDCE7717A");
				databases.Add("ReportServer$SQLEXPRESS", "test");
				databases.Add("ReportServer$SQLEXPRESSTempDB", "report123CFSDfv#");
				databases.Add("Northwind", "adminadmin");
				databases.Add("testdb", "passwordtestdbQWERTY12345!@#$%^");
				databases.Add("testdbBackup", "passwordtestdbQWERTY12345!@#$%^BACKUP");
				return databases[databaseName];
			}
		}

		public TestorSecurityAlertResult SetSecurityAlert(string uniqId)
		{
			TestorSecurityAlertResult retValue = new TestorSecurityAlertResult();
			retValue.ShowAlert = true;
			retValue.UniqId = String.Empty;
			using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
			{
				var session = (from c in dataContext.TestSessions
							   where c.UserId == Provider.CurrentUser.UserId
							   orderby c.StartTime descending
							   select new
							   {
								   c.TestSessionId,
								   c.UniqId
							   }).FirstOrDefault();
				if (session == null)
					return retValue;
				retValue.UniqId = session.UniqId;
				if (session.UniqId.Length != 5)
					return retValue;
				if (session.UniqId != uniqId)
				{
					dataContext.TestSessions.Where(c => c.TestSessionId == session.TestSessionId).First().UniqId = Provider.ClientIP;
					dataContext.SubmitChanges();
					retValue.UniqId = Provider.ClientIP;
					return retValue;
				}
				retValue.ShowAlert = false;
				return retValue;
			}
		}
	}
}

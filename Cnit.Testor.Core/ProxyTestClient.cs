using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnit.Testor.Core.Server;
using System.ServiceModel;

namespace Cnit.Testor.Core
{
	public sealed class ProxyTestClient : ITestClient
	{
		private ITestClient _testClient;
		private ChannelFactory<ITestClient> _factory;

		public ProxyTestClient(ChannelFactory<ITestClient> factory)
		{
			_factory = factory;
			_testClient = _factory.CreateChannel();
		}

		public StartTestParams StartTest(int testId)
		{
			try
			{
				return _testClient.StartTest(testId);
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.StartTest(testId);
			}
		}

		public StartTestParams GetNotCommitedSessions(int userId, bool getLastSession)
		{
			try
			{
				return _testClient.GetNotCommitedSessions(userId, getLastSession);
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.GetNotCommitedSessions(userId, getLastSession);
			}
		}

		public TestorData GetQuestionData(int questId, bool getBLOBs)
		{
			try
			{
				return _testClient.GetQuestionData(questId, getBLOBs);
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.GetQuestionData(questId, getBLOBs);
			}
		}

		public byte[] GetQuestion(int questId, bool getBLOBs)
		{
			try
			{
				return _testClient.GetQuestion(questId, getBLOBs);
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.GetQuestion(questId, getBLOBs);
			}
		}

		public QuestAnswerResult ProcessAnswer(int questId, Dictionary<string, List<string>> requestParams)
		{
			try
			{
				return _testClient.ProcessAnswer(questId, requestParams);
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.ProcessAnswer(questId, requestParams);
			}
		}

		public EndSessionResult EndSession()
		{
			try
			{
				return _testClient.EndSession();
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.EndSession();
			}
		}

		public int AddAdditionalTime(short minutes, DateTime startTime, DateTime endTime,
			int groupId, int testId, int studentId)
		{
			try
			{
				return _testClient.AddAdditionalTime(minutes, startTime, endTime, groupId, testId, studentId);
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.AddAdditionalTime(minutes, startTime, endTime, groupId, testId, studentId);
			}
		}

		public TestSessionStatistics[] GetStatistics(DateTime startTime, DateTime endTime,
			int groupId, int testId, int studentId)
		{
			try
			{
				return _testClient.GetStatistics(startTime, endTime, groupId, testId, studentId);
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.GetStatistics(startTime, endTime, groupId, testId, studentId);
			}
		}

		public TestSessionStatistics GetSessionStatistics(int sessionId)
		{
			try
			{
				return _testClient.GetSessionStatistics(sessionId);
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.GetSessionStatistics(sessionId);
			}
		}

		public GetTestStatisticsResult GetTestStatistics(int testId, int groupId)
		{
			try
			{
				return _testClient.GetTestStatistics(testId, groupId);
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.GetTestStatistics(testId, groupId);
			}
		}

		public void ChangeSessionScore(int sessionId, double score)
		{
			try
			{
				_testClient.ChangeSessionScore(sessionId, score);
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				_testClient.ChangeSessionScore(sessionId, score);
			}
		}

		public void DeleteSession(int sessionId)
		{
			try
			{
				_testClient.DeleteSession(sessionId);
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				_testClient.DeleteSession(sessionId);
			}
		}

		public AppealResult GetQuestionAppeal(int sessionId, int questId, bool getBLOBs)
		{
			try
			{
				return _testClient.GetQuestionAppeal(sessionId, questId, getBLOBs);
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.GetQuestionAppeal(sessionId, questId, getBLOBs);
			}
		}

		public string GetAppealHtml(int sessionId)
		{
			try
			{
				return _testClient.GetAppealHtml(sessionId);
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.GetAppealHtml(sessionId);
			}
		}

		public int[] GetSessionQuestions(int sessionId)
		{
			try
			{
				return _testClient.GetSessionQuestions(sessionId);
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.GetSessionQuestions(sessionId);
			}
		}

		public byte[] GetImage(string imageId)
		{
			try
			{
				return _testClient.GetImage(imageId);
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.GetImage(imageId);
			}
		}

		public TestorTreeItem[] GetCurrentUserFailRequirements(int testId)
		{
			try
			{
				return _testClient.GetCurrentUserFailRequirements(testId);
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.GetCurrentUserFailRequirements(testId);
			}
		}

		public bool IsPassagesNumberNotOverlimit(int testId)
		{
			try
			{
				return _testClient.IsPassagesNumberNotOverlimit(testId);
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.IsPassagesNumberNotOverlimit(testId);
			}
		}


		public TestorTreeItem[] GetAppointedTests()
		{
			try
			{
				return _testClient.GetAppointedTests();
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.GetAppointedTests();
			}
		}

		public string[] GetDatabaseNamesList()
		{
			try
			{
				return _testClient.GetDatabaseNamesList();
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.GetDatabaseNamesList();
			}
		}

		public string GetDatabasePassword(string databaseName)
		{
			try
			{
				return _testClient.GetDatabasePassword(databaseName);
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.GetDatabasePassword(databaseName);
			}
		}

		public TestorSecurityAlertResult SetSecurityAlert(string uniqId)
		{
			try
			{
				return _testClient.SetSecurityAlert(uniqId);
			}
			catch (CommunicationException)
			{
				_testClient = _factory.CreateChannel();
				return _testClient.SetSecurityAlert(uniqId);
			}
		}
	}
}

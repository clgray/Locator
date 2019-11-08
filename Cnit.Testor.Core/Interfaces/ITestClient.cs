using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cnit.Testor.Core.Server;

namespace Cnit.Testor.Core
{
    [ServiceContract(Namespace = "http://testor.ru")]
    public interface ITestClient
    {
        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        StartTestParams StartTest(int testId);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        StartTestParams GetNotCommitedSessions(int userId, bool getLastSession);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        TestorData GetQuestionData(int questId, bool getBLOBs);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        byte[] GetQuestion(int questId, bool getBLOBs);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        TestorTreeItem[] GetCurrentUserFailRequirements(int testId);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        AppealResult GetQuestionAppeal(int sessionId, int questId, bool getBLOBs);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        string GetAppealHtml(int sessionId);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        QuestAnswerResult ProcessAnswer(int questId, Dictionary<string, List<string>> requestParams);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        EndSessionResult EndSession();

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        void ChangeSessionScore(int sessionId, double score);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        void DeleteSession(int sessionId);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        int AddAdditionalTime(short minutes, DateTime startTime, DateTime endTime,
            int groupId, int testId, int studentId);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        TestSessionStatistics[] GetStatistics(DateTime startTime, DateTime endTime,
            int groupId, int testId, int studentId);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        TestSessionStatistics GetSessionStatistics(int sessionId);

		[FaultContract(typeof(AccessFaultException))]
		[OperationContract]
		GetTestStatisticsResult GetTestStatistics(int testId, int groupId);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        int[] GetSessionQuestions(int sessionId);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        byte[] GetImage(string imageId);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        bool IsPassagesNumberNotOverlimit(int testId);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        TestorTreeItem[] GetAppointedTests();

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        string[] GetDatabaseNamesList();

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        string GetDatabasePassword(string databaseName);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        TestorSecurityAlertResult SetSecurityAlert(string uniqId);
    }
}

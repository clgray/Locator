using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Cnit.Testor.Core.Server
{
    [Serializable]
    public sealed class ServerHelper
    {
        [NonSerialized]
        private TestorSecurityProvider _provider;

        private TestorSecurityProvider Provider
        {
            get
            {
                if (_provider == null)
                    _provider = new TestorSecurityProvider(HttpContext.Current);
                return _provider;
            }
        }

        public TestorTreeItem[] GetTestRequirements(int testId)
        {
            Provider.TestRoles(TestorUserRole.Anonymous, TestorUserRole.Student, TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                var req = dataContext.GetTestRequirements(testId);
                List<TestorTreeItem> retValue = new List<TestorTreeItem>();
                foreach (var current in req)
                {
                    TestorTreeItem item = new TestorTreeItem(
                       current.NodeId, current.Requirement, current.TestName, TestorItemType.Test, null);
                    retValue.Add(item);
                }
                return retValue.ToArray();
            }
        }

        public TestorData GetTestSettingsData(int testId)
        {
            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                CoreTest test = dataContext.CoreTests.Where(c => c.TestId == testId).FirstOrDefault();
                TestorData data = new TestorData();
                TestorData.CoreTestsRow coreTestRow = data.CoreTests.NewCoreTestsRow();
                coreTestRow.AllowAdmitQuestions = test.AllowAdmitQuestions;
                coreTestRow.BeginTime = test.BeginTime;
                coreTestRow.Description = test.Description;
                coreTestRow.EndTime = test.EndTime;
                coreTestRow.IsActive = test.IsActive;
                coreTestRow.IsMasterTest = test.IsMasterTest;
                coreTestRow.PassagesNumber = test.PassagesNumber;
                coreTestRow.PassingScore = test.PassingScore;
                coreTestRow.QuestionsNumber = test.QuestionsNumber;
                coreTestRow.IsDeleted = test.IsDeleted;
                if (coreTestRow.QuestionsNumber == 0)
                {
                    if (test.IsMasterTest)
                    {
                        var masterParts = dataContext.CoreMasterParts.Where(c => c.MasterTestId == testId);
                        if (masterParts.Count() > 0)
                            coreTestRow.QuestionsNumber = (short)masterParts.Sum(c => c.QuestionsNumber);
                        else
                            coreTestRow.QuestionsNumber = 0;
                    }
                    else
                        coreTestRow.QuestionsNumber = (short)test.CoreQuestions.Count();
                }
                coreTestRow.ShowRightAnswersCount = test.ShowRightAnswersCount;
                coreTestRow.ShowTestResult = test.ShowTestResult;
                coreTestRow.ShowDetailsTestResult = test.ShowDetailsTestResult;
                coreTestRow.TestId = test.TestId;
                coreTestRow.TestKey = test.TestKey;
                coreTestRow.TestName = test.TestName;
                coreTestRow.TimeLimit = test.TimeLimit;
                coreTestRow.VariantsMode = test.VariantsMode;
                coreTestRow.AdaptiveMode = test.AdaptiveMode;
                data.CoreTests.AddCoreTestsRow(coreTestRow);
                return data;
            }
        }
    }
}

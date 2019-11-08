using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Cnit.Testor.Core;
using System.Reflection;
using System.Threading;
using System.Data.Linq;
using Cnit.Testor.Core.Packaging;
using System.Diagnostics;

namespace Cnit.Testor.Core.Server.Services
{
    [Serializable]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, AddressFilterMode = AddressFilterMode.Any)]
    public sealed class TestEdit : TestorServiceBase, ITestEdit
    {
        public TestorTreeItem[] SendTests(byte[] testorData, int folderId, int[] groupIds)
        {
            Debug.Assert(testorData != null);
            Debug.Assert(folderId >= 0);

            Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                TestorData data = DataCompressor.DecompressData<TestorData>(testorData);

                //data.WriteXml("C:/locator.xml", System.Data.XmlWriteMode.IgnoreSchema);

                Dictionary<int, CoreTest> xTests = new Dictionary<int, CoreTest>();
                foreach (TestorData.CoreTestsRow coreTest in data.CoreTests)
                {
                    CoreTest test = new CoreTest();
                    test.TestKey = coreTest.TestKey;
                    test.IsMasterTest = coreTest.IsMasterTest;
                    CreateCoreTest(coreTest, test);
                    xTests.Add(coreTest.TestId, test);
                    dataContext.CoreTests.InsertOnSubmit(test);
                    foreach (int groupId in groupIds)
                    {
                        TestGroup group = new TestGroup();
                        group.CoreTest = test;
                        group.GroupId = groupId;
                        dataContext.TestGroups.InsertOnSubmit(group);
                    }
                    foreach (var coreQuest in coreTest.GetCoreQuestionsRows())
                    {
                        CoreQuestion quest = new CoreQuestion();
                        quest.CoreTest = test;
                        quest.QuestionType = coreQuest.QuestionType;
                        quest.Question = coreQuest.Question;
                        quest.QuestionMark = coreQuest.QuestionMark;
                        try
                        {
                            if (!Convert.IsDBNull(coreQuest.QuestionMetadata))
                                quest.QuestionMetadata = coreQuest.QuestionMetadata;
                        }
                        catch
                        {
                            quest.QuestionMetadata = null;
                        }
                        dataContext.CoreQuestions.InsertOnSubmit(quest);
                        foreach (var coreAnswer in coreQuest.GetCoreAnswersRows())
                        {
                            CoreAnswer answer = new CoreAnswer();
                            answer.CoreQuestion = quest;
                            answer.Answer = coreAnswer.Answer;
                            answer.IsTrue = coreAnswer.IsTrue;
                            try
                            {
                                if (!Convert.IsDBNull(coreAnswer.AnswerMetadata))
                                    answer.AnswerMetadata = coreAnswer.AnswerMetadata;
                            }
                            catch
                            {
                                answer.AnswerMetadata = null;
                            }
                            dataContext.CoreAnswers.InsertOnSubmit(answer);
                        }
                        foreach (var coreBlob in coreQuest.GetCoreBLOBsRows())
                        {
                            CoreBLOB blob = new CoreBLOB();
                            blob.CoreQuestion = quest;
                            blob.BLOBId = coreBlob.BLOBId;
                            blob.BLOBContent = coreBlob.BLOBContent;
                            dataContext.CoreBLOBs.InsertOnSubmit(blob);
                        }
                    }
                }
                foreach (var masterTest in data.CoreTests.Where(c => c.IsMasterTest == true))
                {
                    var parts = data.CoreMasterParts.Where(c => c.MasterTestId == masterTest.TestId);
                    var test = xTests.Where(c => c.Value.TestKey == masterTest.TestKey).FirstOrDefault();
                    foreach (var part in parts)
                    {
                        CoreMasterPart masterPart = new CoreMasterPart();
                        masterPart.CoreTest1 = test.Value;
                        masterPart.CoreTest = xTests.Where(
                            c => c.Key == part.PartTestId).FirstOrDefault().Value;
                        masterPart.QuestionsNumber = part.QuestionsNumber;
                        dataContext.CoreMasterParts.InsertOnSubmit(masterPart);
                    }
                }
                foreach (var coreReq in data.CoreRequirements)
                {
                    CoreRequirement req = new CoreRequirement();
                    Guid testKey = data.CoreTests.Where(c => c.TestId == coreReq.TestId).FirstOrDefault().TestKey;
                    Guid reqKey = data.CoreTests.Where(c => c.TestId == coreReq.Requirement).FirstOrDefault().TestKey;
                    req.CoreTest = xTests.Where(c => c.Value.TestKey == testKey).FirstOrDefault().Value;
                    req.CoreTest1 = xTests.Where(c => c.Value.TestKey == reqKey).FirstOrDefault().Value;
                    dataContext.CoreRequirements.InsertOnSubmit(req);
                }
                try
                {
                    dataContext.SubmitChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                List<TestorTreeItem> retValue = new List<TestorTreeItem>();
                foreach (var test in xTests)
                {
                    CoreTest coreTest = test.Value;
                    TestorItemType type = TestorItemType.Test;
                    if (coreTest.IsMasterTest)
                        type = TestorItemType.MasterTest;
                    int result = dataContext.AddTestTreeItem(GetId(folderId), (byte)type, coreTest.TestId, Provider.CurrentUser.UserId);
                    TestorTreeItem item = new TestorTreeItem(result, coreTest.TestId,
                        coreTest.TestName, type, null);
                    retValue.Add(item);
                }
                return retValue.ToArray();
            }
        }

        //Не является операцией сервиса
        private void CreateCoreTest(TestorData.CoreTestsRow coreTest, CoreTest test)
        {
            test.TestName = coreTest.TestName;
            test.Description = coreTest.Description;
            test.QuestionsNumber = coreTest.QuestionsNumber;
            test.VariantsMode = coreTest.VariantsMode;
            test.PassagesNumber = coreTest.PassagesNumber;
            test.PassingScore = coreTest.PassingScore;
            test.TimeLimit = coreTest.TimeLimit;
            test.BeginTime = coreTest.BeginTime;
            test.EndTime = coreTest.EndTime;
            test.AllowAdmitQuestions = coreTest.AllowAdmitQuestions;
            test.ShowTestResult = coreTest.ShowTestResult;
            test.ShowDetailsTestResult = coreTest.ShowDetailsTestResult;
            test.ShowRightAnswersCount = coreTest.ShowRightAnswersCount;
            test.IsActive = coreTest.IsActive;
            test.AdaptiveMode = coreTest.AdaptiveMode;
        }

        public void RemoveItem(int itemId, TestingServerItemType itemType)
        {
            Debug.Assert(itemId > 0);

            Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                switch (itemType)
                {
                    case TestingServerItemType.TestTree:
                        {
                            Provider.TestTreeAccess(itemId);
                            int testId = dataContext.RemoveTestTreeItem(itemId);
                            if (testId != 0)
                            {
                                var test = dataContext.CoreTests.Where(c => c.TestId == testId).First();
                                test.IsDeleted = true;
                                dataContext.CoreRequirements.DeleteAllOnSubmit(
                                    dataContext.CoreRequirements.Where(c => c.TestId == test.TestId ||
                                    c.Requirement == test.TestId));
                                dataContext.TestGroups.DeleteAllOnSubmit(test.TestGroups);
                                dataContext.CoreMasterParts.DeleteAllOnSubmit(test.CoreMasterParts);
                                dataContext.CoreMasterParts.DeleteAllOnSubmit(test.CoreMasterParts1);
                                dataContext.SubmitChanges();
                            }
                        } break;
                    case TestingServerItemType.GroupTree:
                        {
                            Provider.TestRoles(TestorUserRole.Administrator);
                            dataContext.RemoveGroupTreeItem(itemId);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void RenameItem(int itemId, string newName, TestingServerItemType itemType)
        {
            Debug.Assert(itemId > 0);
            Debug.Assert(!String.IsNullOrEmpty(newName));

            Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                switch (itemType)
                {
                    case TestingServerItemType.TestTree:
                        {
                            Provider.TestTreeAccess(itemId);
                            dataContext.RenameTestTreeItem(itemId, newName);
                        } break;
                    case TestingServerItemType.GroupTree:
                        {
                            Provider.TestRoles(TestorUserRole.Administrator);
                            dataContext.RenameGroupTreeItem(itemId, newName);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void SetItemParent(int itemId, int newParent, TestingServerItemType itemType)
        {
            Debug.Assert(itemId > 0);
            Debug.Assert(newParent >= 0);

            Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                switch (itemType)
                {
                    case TestingServerItemType.None:
                        break;
                    case TestingServerItemType.TestTree:
                        {
                            Provider.TestTreeAccess(itemId);
                            dataContext.ReparentTestTreeItem(itemId, newParent);
                        }
                        break;
                    case TestingServerItemType.GroupTree:
                        {
                            Provider.TestRoles(TestorUserRole.Administrator);
                            dataContext.ReparentGroupTreeItem(itemId, newParent);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public byte[] GetTestSettings(int testId)
        {
            Debug.Assert(testId > 0);

            Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian,
                TestorUserRole.Student, TestorUserRole.Anonymous);

            var data = Helper.GetTestSettingsData(testId);
            return DataCompressor.CompressData(data);
        }

        public int[] GetTestGroups(int testId)
        {
            Debug.Assert(testId > 0);

            Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                List<int> retValue = new List<int>();
                var ids = from c in dataContext.GetUserGroupTree(Provider.CurrentUser.UserRole == TestorUserRole.Administrator
                            || Provider.CurrentUser.UserRole == TestorUserRole.Anonymous ? 0 : Provider.CurrentUser.UserId,
                            null, true, null)
                          select c.GroupId;
                var groups = from c in dataContext.TestGroups.Where(c => c.TestId == testId && ids.Contains(c.GroupId))
                             select new { Group = c.GroupId };
                foreach (var group in groups)
                    retValue.Add(group.Group);
                return retValue.ToArray();
            }
        }

        public void SetTestGroups(int testId, int[] addGroups, int[] remGroups)
        {
            Debug.Assert(testId > 0);

            Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                Provider.TestCoreTestsAccess(testId);

                var test = dataContext.CoreTests.Where(c => c.TestId == testId).FirstOrDefault();
                if (test == null)
                    return;
                var ids = (from c in dataContext.GetUserGroupTree(Provider.CurrentUser.UserRole == TestorUserRole.Administrator
                          || Provider.CurrentUser.UserRole == TestorUserRole.Anonymous ? 0 : Provider.CurrentUser.UserId,
                          null, true, null)
                           select c.GroupId).ToArray();
                var aGroups = addGroups.Where(c => ids.Contains(c));
                var rGroups = remGroups.Where(c => ids.Contains(c));
                dataContext.TestGroups.DeleteAllOnSubmit(test.TestGroups.Where(
                    c => rGroups.Contains(c.GroupId) || aGroups.Contains(c.GroupId)));
                foreach (int groupId in aGroups)
                {
                    TestGroup group = new TestGroup();
                    group.CoreTest = test;
                    group.GroupId = groupId;
                    dataContext.TestGroups.InsertOnSubmit(group);
                }
                dataContext.SubmitChanges();
            }
        }

        public void SetTestSettings(byte[] testSettings)
        {
            Debug.Assert(testSettings != null);

            Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                TestorData data = DataCompressor.DecompressData<TestorData>(testSettings);
                TestorData.CoreTestsRow test = data.CoreTests[0];

                Provider.TestCoreTestsAccess(test.TestId);

                CoreTest coreTest = dataContext.CoreTests.Where(c => c.TestId == test.TestId).FirstOrDefault();
                CreateCoreTest(test, coreTest);
                dataContext.SubmitChanges();
            }
        }

        public TestorTreeItem CreateFolder(int parentId, string folderName)
        {
            Debug.Assert(parentId >= 0);
            Debug.Assert(!String.IsNullOrEmpty(folderName));

            Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                TestorData td = new TestorData();
                TestorData.CoreTestsRow testRow = HtmlStore.CreateCoreTest(td, folderName);
                CoreTest coreTest = new CoreTest();
                CreateCoreTest(testRow, coreTest);
                dataContext.CoreTests.InsertOnSubmit(coreTest);
                dataContext.SubmitChanges();
                int result = dataContext.AddTestTreeItem(GetId(parentId), (int)TestorItemType.Folder, coreTest.TestId, Provider.CurrentUser.UserId);
                TestorTreeItem retValue = new TestorTreeItem(
                       result, coreTest.TestId, folderName, TestorItemType.Folder, new TestorTreeItem[] { });
                retValue.ItemOwner = Provider.CurrentUser.UserId;
                return retValue;
            }
        }

        //Не является операцией сервиса
        private int? GetId(int pid)
        {
            int? retValue = null;
            if (pid > 0)
                retValue = pid;
            return retValue;
        }

        public TestorTreeItem[] GetServerTree(int parentId, int levelsNumber, TestingServerItemType itemType)
        {
            Debug.Assert(parentId >= 0);

            Provider.TestRoles(TestorUserRole.Anonymous, TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian,
                TestorUserRole.Student);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                int i = -1;
                if (itemType == TestingServerItemType.TestTree || itemType == TestingServerItemType.ActiveTestTree || itemType == TestingServerItemType.FolderTree)
                {
                    if (Provider.CurrentUser.UserRole == TestorUserRole.Anonymous && parentId == 0)
                        if (!CoreConfiguration.GetAnonymousPolicy(ref parentId))
                            return new TestorTreeItem[] { };
                }
                switch (itemType)
                {
                    case TestingServerItemType.TestTree:
                        {
                            var results = dataContext.GetTestTreeByLevel(GetId(parentId), GetId(levelsNumber), false, false).ToArray();
                            return GetTestTreeItems(ref i, results, false);
                        };
                    case TestingServerItemType.ActiveTestTree:
                        {
                            var results = dataContext.GetTestTreeByLevel(GetId(parentId), GetId(levelsNumber), false, true).ToArray();
                            return GetTestTreeItems(ref i, results, true);
                        };
                    case TestingServerItemType.FolderTree:
                        {
                            var results = dataContext.GetTestTreeByLevel(GetId(parentId), GetId(levelsNumber), false, false).Where(c => c.NodeType == (byte)TestorItemType.Folder).ToArray();
                            return GetTestTreeItems(ref i, results, false);
                        };
                    case TestingServerItemType.GroupTree:
                        {
                            var results = dataContext.GetUserGroupTree(Provider.CurrentUser.UserRole == TestorUserRole.Administrator
                                || Provider.CurrentUser.UserRole == TestorUserRole.Anonymous ? 0 : Provider.CurrentUser.UserId,
                                GetId(parentId), true, GetId(levelsNumber)).ToArray();
                            return GetGroupTreeItems(ref i, results);
                        };
                    default:
                        return null;
                }
            }
        }

        public TestorTreeItem[] GetTestParents(int itemId)
        {
            Debug.Assert(itemId >= 0);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                GetTestTreeByLevelResult[] results = null;
                if (Provider.CurrentUser.UserRole == TestorUserRole.Anonymous)
                {
                    int xId = 0;
                    if (!CoreConfiguration.GetAnonymousPolicy(ref xId))
                        return new TestorTreeItem[] { };
                    results = dataContext.GetTestTreeByLevel(itemId, 0, true, false).ToArray();
                    List<GetTestTreeByLevelResult> newResults = new List<GetTestTreeByLevelResult>();
                    if (xId > 0)
                    {
                        bool hasBreak = false;
                        foreach (var res in results.Reverse())
                        {
                            if (res.NodeId == xId)
                            {
                                hasBreak = true;
                                break;
                            }
                            newResults.Add(res);
                        }
                        if (!hasBreak && results.Length != 0)
                            return null;
                        newResults.Reverse();
                        results = newResults.ToArray();
                    }
                }
                else
                    results = dataContext.GetTestTreeByLevel(itemId, 0, true, false).ToArray();
                int i = -1;
                return GetTestTreeItems(ref i, results, false);
            }
        }

        //Не является операцией сервиса
        private TestorTreeItem[] GetTestTreeItems(ref int i, GetTestTreeByLevelResult[] results, bool isActive)
        {
            List<TestorTreeItem> retValue = new List<TestorTreeItem>();
            int sl = 0;
            if (i != -1)
            {
                GetTestTreeByLevelResult currentItem = results[i];
                sl = currentItem.TreeNode.Split('/').Length;
            }
            for (i++; i < results.Length; i++)
            {
                GetTestTreeByLevelResult value = results[i];
                if (value.TreeNode.Split('/').Length <= sl)
                {
                    i--;
                    break;
                }
                TestorItemType type = (TestorItemType)value.NodeType;
                if (type == TestorItemType.Folder)
                {
                    TestorTreeItem item = new TestorTreeItem(value.NodeId, value.TestId.Value, value.TestName,
                                           type, GetTestTreeItems(ref i, results, isActive));
                    item.ItemOwner = value.ItemOwner;
                    item.IsActive = value.TestTreeIsActive;
                    if (!isActive || value.TestTreeIsActive == true)
                        retValue.Add(item);
                }
                else if (type == TestorItemType.Test || type == TestorItemType.MasterTest)
                {
                    TestorTreeItem item = new TestorTreeItem(value.NodeId, value.TestId.Value, value.TestName,
                                            type, GetTestTreeItems(ref i, results, isActive));
                    item.ItemOwner = value.ItemOwner;
                    item.IsActive = value.TestTreeIsActive;
                    retValue.Add(item);
                }
            }
            return retValue.ToArray();
        }

        //Не является операцией сервиса
        private TestorTreeItem[] GetGroupTreeItems(ref int i, GetUserGroupTreeResult[] results)
        {
            List<TestorTreeItem> retValue = new List<TestorTreeItem>();
            int sl = 0;
            string slStr = String.Empty;
            if (i != -1)
            {
                GetUserGroupTreeResult currentItem = results[i];
                slStr = currentItem.GroupNode;
                sl = slStr.Split('/').Length;
            }
            for (i++; i < results.Length; i++)
            {
                GetUserGroupTreeResult value = results[i];
                if (value.GroupNode.Split('/').Length <= sl || !value.GroupNode.StartsWith(slStr))
                {
                    i--;
                    break;
                }
                TestorTreeItem item = new TestorTreeItem(value.GroupId, null, value.GroupName,
                                       TestorItemType.Group, GetGroupTreeItems(ref i, results));
                item.GroupCode = value.GroupCode;
                retValue.Add(item);
            }
            return retValue.ToArray();
        }

        public TestorTreeItem[] AddGroups(int parentId, TestorTreeItem[] groups)
        {
            Debug.Assert(parentId >= 0);

            Provider.TestRoles(TestorUserRole.Administrator);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                foreach (TestorTreeItem group in groups)
                {
                    int i = 1;
                    string groupCode = String.Empty;
                    while (i > 0)
                    {
                        groupCode = Guid.NewGuid().ToString().Substring(0, 8);
                        i = dataContext.GetGroupIdByCode(groupCode);
                    }
                    group.GroupCode = groupCode;
                    group.ItemId = dataContext.AddGroupTreeItem(GetId(parentId), group.ItemName, groupCode);
                    AddGroups(group.ItemId, group.SubItems);
                }
                return groups;
            }
        }

        public TestorMasterPart[] GetTestMasterParts(int testId)
        {
            Debug.Assert(testId > 0);

            Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                var req = from c in dataContext.CoreMasterParts
                          join u in dataContext.CoreTests on c.PartTestId equals u.TestId
                          where c.MasterTestId == testId
                          select new TestorMasterPart
                          {
                              Name = u.TestName,
                              PartTestId = c.PartTestId,
                              QuestionsNumber = c.QuestionsNumber
                          };
                return req.ToArray();
            }
        }

        public void SetTestMasterParts(TestorMasterPart[] masterParts, int testId)
        {
            Debug.Assert(testId > 0);
            Debug.Assert(masterParts != null);

            Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

            Provider.TestCoreTestsAccess(testId);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                dataContext.CoreMasterParts.DeleteAllOnSubmit(
                    dataContext.CoreMasterParts.Where(c => c.MasterTestId == testId));
                foreach (var part in masterParts)
                {
                    CoreMasterPart newPart = new CoreMasterPart();
                    newPart.MasterTestId = testId;
                    newPart.PartTestId = part.PartTestId;
                    newPart.QuestionsNumber = part.QuestionsNumber;
                    dataContext.CoreMasterParts.InsertOnSubmit(newPart);
                }
                dataContext.SubmitChanges();
            }
        }

        public TestorTreeItem[] GetTestRequirements(int testId)
        {
            Debug.Assert(testId > 0);

            return Helper.GetTestRequirements(testId);
        }

        public void SetTestRequirements(TestorTreeItem[] testRequirements, int testId)
        {
            Debug.Assert(testId > 0);
            Debug.Assert(testRequirements != null);

            Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

            Provider.TestCoreTestsAccess(testId);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                dataContext.CoreRequirements.DeleteAllOnSubmit(
                    dataContext.CoreRequirements.Where(c => c.TestId == testId));
                foreach (var req in testRequirements)
                {
                    CoreRequirement newReq = new CoreRequirement();
                    newReq.TestId = testId;
                    newReq.Requirement = req.TestId.Value;
                    dataContext.CoreRequirements.InsertOnSubmit(newReq);
                }
                dataContext.SubmitChanges();
            }
        }

        public byte[] GetTestHTML(int testId)
        {
            Debug.Assert(testId > 0);

            Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);
            Provider.TestCoreTestsAccess(testId);

            List<HtmlStore> retValue = new List<HtmlStore>();
            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                var quests = from c in dataContext.CoreQuestions
                             where c.TestId == testId
                             orderby c.QuestionId
                             select c;

                foreach (var quest in quests)
                {
                    HtmlStore store = new HtmlStore();
                    store.Html = quest.Question;
                    foreach (var answer in quest.CoreAnswers)
                    {
                        HtmlStore answerStore = new HtmlStore();
                        answerStore.Html = answer.Answer;
                        answerStore.IsTrue = answer.IsTrue;
                        store.SubItems.Add(answerStore);
                    }

                    foreach (var blob in quest.CoreBLOBs)
                    {
                        store.Images.Add(blob.BLOBId, blob.BLOBContent.ToArray());
                    }

                    retValue.Add(store);
                }
                return DataCompressor.CompressData<HtmlStore[]>(retValue.ToArray());
            }
        }

        public void SetTestTreeItemActivity(int nodeId, bool isActive)
        {
            Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                dataContext.SetTestTreeItemActivity(nodeId, isActive);
                dataContext.SubmitChanges();
            }
        }
    }
}

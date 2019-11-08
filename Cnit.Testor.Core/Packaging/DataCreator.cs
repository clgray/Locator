using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace Cnit.Testor.Core.Packaging
{
    public static class DataCreator
    {
        public static TestorData CreateFullTestorDataSet(List<TestHelper> helpers)
        {
            TestorData retValue = new TestorData();
            int testId = 1, questId = 1, ansId = 1;
			foreach (var helper in helpers)
            {
                TestorData td = helper.TestorData;
                object[] arr = td.CoreTests.Rows[0].ItemArray;
                arr[0] = testId;
                retValue.CoreTests.Rows.Add(arr);
                foreach (TestorData.CoreQuestionsRow row in td.CoreQuestions)
                {
                    object[] questArr = row.ItemArray;
                    questArr[0] = questId;
                    questArr[1] = testId;
                    retValue.CoreQuestions.Rows.Add(questArr);
                    foreach (var answer in td.CoreAnswers.Where(c => c.CoreQuestionsRow == row))
                    {
                        object[] ansArr = answer.ItemArray;
                        ansArr[0] = ansId;
                        ansArr[1] = questId;
                        retValue.CoreAnswers.Rows.Add(ansArr);
                        ansId++;
                    }
                    foreach (var blob in td.CoreBLOBs.Where(c => c.CoreQuestionsRow == row))
                    {
                        object[] blobArr = blob.ItemArray;
                        blobArr[1] = questId;
                        retValue.CoreBLOBs.Rows.Add(blobArr);
                    }
                    questId++;
                }
                testId++;
            }
            foreach (var helper in helpers)
            {
                var test = retValue.CoreTests.Where(c => c.TestKey == new Guid(helper.TestKey)).First();
                foreach (var req in helper.TestRequirements)
                {
                    TestorData.CoreRequirementsRow reqRow = retValue.CoreRequirements.NewCoreRequirementsRow();
                    reqRow.TestId = test.TestId;
                    reqRow.Requirement = retValue.CoreTests.Where(
                        c => c.TestKey == new Guid(req)).First().TestId;
                    retValue.CoreRequirements.AddCoreRequirementsRow(reqRow);
                }
                if (helper.IsMasterTest)
                {
                    foreach (var subTest in helper.SubTests)
                    {
						try
						{
							TestorData.CoreMasterPartsRow subTestRow = retValue.CoreMasterParts.NewCoreMasterPartsRow();
							subTestRow.MasterTestId = test.TestId;
							subTestRow.PartTestId = retValue.CoreTests.Where(
								c => c.TestKey == new Guid(subTest.Key)).First().TestId;
							subTestRow.QuestionsNumber = subTest.Value;
							retValue.CoreMasterParts.AddCoreMasterPartsRow(subTestRow);
						}
						catch
						{
							continue;
						}
                    }
                }
            }
            return retValue;
        }
    }
}

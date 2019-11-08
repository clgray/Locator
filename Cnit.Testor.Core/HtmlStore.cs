using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Data;
using System.Globalization;

namespace Cnit.Testor.Core
{
    [Serializable]
    public sealed class HtmlStore
    {
        private string _html;
        private bool _isTrue = false;
        private Dictionary<Guid, byte[]> _images;
        private List<HtmlStore> _subItems;
        private QuestionType _questType = QuestionType.SingleAnswerQuestion;
        private int _questIndex;

        public bool IsAppeal { get; set; }
        public bool AppealIsRight { get; set; }
        public string Answer { get; set; }

        private string RemoveBr(string html)
        {
            if (String.IsNullOrEmpty(html))
                return html;
            html = html.Trim();
            if (html.EndsWith("<br/>"))
            {
                html = html.Remove(html.Length - "<br/>".Length);
                return RemoveBr(html);
            }
            if (html.EndsWith("<br>"))
            {
                html = html.Remove(html.Length - "<br>".Length);
                return RemoveBr(html);
            }
            else
                return html;
        }

        public string NoBrHtml
        {
            get
            {
                return RemoveBr(_html);
            }
        }

        public string Html
        {
            get
            {
                return _html;
            }
            set
            {
                _html = value;
            }
        }

        public bool IsTrue
        {
            get
            {
                return _isTrue;
            }
            set
            {
                _isTrue = value;
            }
        }

        public QuestionType QuestionType
        {
            get
            {
                return _questType;
            }
            set
            {
                _questType = value;
            }
        }

        public List<HtmlStore> SubItems
        {
            get
            {
                return _subItems;
            }
            set
            {
                _subItems = value;
            }
        }

        public IOrderedEnumerable<HtmlStore> RandomSubItems
        {
            get
            {
                return _subItems.OrderBy(c => Guid.NewGuid()).OrderBy(c => Guid.NewGuid());
            }
        }


        public Dictionary<Guid, byte[]> Images
        {
            get
            {
                return _images;
            }
        }

        public int QuestIndex
        {
            get
            {
                return _questIndex;
            }
            set
            {
                _questIndex = value;
            }
        }

        public HtmlStore()
        {
            _images = new Dictionary<Guid, byte[]>();
            _subItems = new List<HtmlStore>();
        }

        public Guid AddImage(byte[] image)
        {
            Guid retValue = Guid.NewGuid();
            _images.Add(retValue, image);
            return retValue;
        }

        public static string GetHtml(string baseUrl, string html)
        {
            string retValue = html;
            retValue = retValue.Replace("#$", baseUrl).Replace("#%", ".");
            return retValue;
        }

        public static TestorData GetDataSet(HtmlStore[] store, FileInfo testFile)
        {
            string testName = String.Empty;
            return GetDataSet(store, testFile, out testName);
        }

        public static TestorData GetDataSet(HtmlStore[] store, FileInfo testFile, out string testName)
        {
            testName = testFile.Name.Replace(testFile.Extension, String.Empty);
            return GetDataSet(store,
                testName);
        }

        public static TestorData GetDataSet(HtmlStore[] store, string testName)
        {
            TestorData retValue = new TestorData();
            TestorData.CoreTestsRow testRow = CreateCoreTest(retValue, testName);
            retValue.CoreTests.AddCoreTestsRow(testRow);
            HtmlStore.AddToDataset(retValue, testRow, store);
            return retValue;
        }

        public static TestorData.CoreTestsRow CreateCoreTest(TestorData data, string testName)
        {
            TestorData.CoreTestsRow testRow = data.CoreTests.NewCoreTestsRow();
            testRow.TestKey = Guid.NewGuid();
            testRow.TestName = testName;
            testRow.VariantsMode = true;
            testRow.IsActive = true;
            testRow.IsMasterTest = false;
            testRow.ShowRightAnswersCount = true;
            testRow.ShowDetailsTestResult = false;
            testRow.ShowTestResult = true;
            testRow.AllowAdmitQuestions = true;
            testRow.Description = String.Empty;
            testRow.QuestionsNumber = 0;
            testRow.PassagesNumber = 0;
            testRow.PassingScore = 0;
            testRow.TimeLimit = 0;
            testRow.BeginTime = DateTime.MinValue;
            testRow.EndTime = DateTime.MinValue;
            testRow.AdaptiveMode = (short)TestorAdaptiveMode.None;
            testRow.IsDeleted = false;
            return testRow;
        }

        public static TestorData.CoreTestsRow AddToDataset(TestorData dataSet, HtmlStore[] store)
        {
            TestorData.CoreTestsRow retValue = CreateCoreTest(dataSet, String.Empty);
            AddToDataset(dataSet, retValue, store);
            return retValue;
        }

        public static void AddToDataset(TestorData dataSet,
            TestorData.CoreTestsRow testRow, HtmlStore[] store)
        {
            if (dataSet == null)
                return;
            foreach (var question in store.OrderBy(c => c.QuestIndex))
            {
                TestorData.CoreQuestionsRow newRow = dataSet.CoreQuestions.NewCoreQuestionsRow();
                newRow.QuestionId = question.QuestIndex;
                newRow.QuestionType = (byte)question.QuestionType;
                newRow.Question = question.Html;
                newRow.TestId = testRow.TestId;
                newRow.QuestionMark = 1;
                dataSet.CoreQuestions.AddCoreQuestionsRow(newRow);
                ProcessBLOBs(dataSet, question, newRow.QuestionId);
                foreach (var answer in question.SubItems)
                {
                    TestorData.CoreAnswersRow ansRow = dataSet.CoreAnswers.NewCoreAnswersRow();
                    ansRow.QuestionId = newRow.QuestionId;
                    ansRow.Answer = answer.Html;
                    ansRow.IsTrue = answer.IsTrue;
                    dataSet.CoreAnswers.AddCoreAnswersRow(ansRow);
                    ProcessBLOBs(dataSet, answer, newRow.QuestionId);
                }
            }
        }

        private static void ProcessBLOBs(TestorData dataSet,
            HtmlStore store, int questionId)
        {
            foreach (var image in store.Images)
            {
                TestorData.CoreBLOBsRow blobRow = dataSet.CoreBLOBs.NewCoreBLOBsRow();
                blobRow.BLOBId = image.Key;
                blobRow.QuestionId = questionId;
                blobRow.BLOBContent = image.Value;
                dataSet.CoreBLOBs.AddCoreBLOBsRow(blobRow);
            }
        }

        public static HtmlStore GetHtmlStore(TestorData testorData, int questionId)
        {
            HtmlStore retValue = new HtmlStore();
            var currentRows = testorData.CoreQuestions.Where(c => c.QuestionId == questionId);
            if (currentRows.Count() == 0)
                return null;
            var currentRow = currentRows.FirstOrDefault();
            retValue.QuestIndex = currentRow.QuestionId;
            retValue.Html = currentRow.Question;
            retValue.QuestionType = (QuestionType)currentRow.QuestionType;
            foreach (var blob in currentRow.GetCoreBLOBsRows())
                retValue.Images.Add(blob.BLOBId, blob.BLOBContent);
            foreach (var ans in currentRow.GetCoreAnswersRows())
            {
                HtmlStore answer = new HtmlStore();
                answer.QuestIndex = ans.AnswerId;
                answer.Html = ans.Answer;
                answer.IsTrue = ans.IsTrue;
                retValue.SubItems.Add(answer);
            }
            return retValue;
        }

        public static double? GetFractionValue(string value)
        {
            double? retValue = null;
            value = value.Trim();
            if (value.Contains('/'))
            {
                var xvalue = value.Split('/');
                if (xvalue.Length == 2)
                {
                    double firstValue = 1;
                    double secondValue = 1;
                    if (double.TryParse(xvalue[0], NumberStyles.Any, CultureInfo.CurrentCulture.NumberFormat, out firstValue))
                    {
                        if (double.TryParse(xvalue[1], NumberStyles.Any, CultureInfo.CurrentCulture.NumberFormat, out secondValue))
                        {
                            retValue = Math.Round(firstValue / secondValue, 4);
                            return retValue;
                        }
                    }
                }
            }
            return retValue;
        }

        public static string GetString(string value)
        {
            return !String.IsNullOrEmpty(value) ? value : String.Empty;
        }
    }
}

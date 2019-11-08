using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnit.Testor.Core
{
    [Serializable]
    public sealed class CoreTestRowAdapter
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public Guid TestKey { get; set; }
        public string Description { get; set; }
        public short QuestionsNumber { get; set; }
        public bool VariantsMode { get; set; }
        public short PassagesNumber { get; set; }
        public double PassingScore { get; set; }
        public int TimeLimit { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool AllowAdmitQuestions { get; set; }
        public bool ShowTestResult { get; set; }
        public bool ShowDetailsTestResult { get; set; }
        public bool ShowRightAnswersCount { get; set; }
        public bool IsActive { get; set; }
        public bool IsMasterTest { get; set; }
        public short AdaptiveMode { get; set; }
        public bool IsDeleted { get; set; }

        public static CoreTestRowAdapter GetAdapter(TestorData.CoreTestsRow row)
        {
            return new CoreTestRowAdapter(row);
        }

        private CoreTestRowAdapter(TestorData.CoreTestsRow row)
        {
            TestId = row.TestId;
            TestName = row.TestName;
            TestKey = row.TestKey;
            Description = row.Description;
            QuestionsNumber = row.QuestionsNumber;
            VariantsMode = row.VariantsMode;
            PassagesNumber = row.PassagesNumber;
            PassingScore = row.PassingScore;
            TimeLimit = row.TimeLimit;
            BeginTime = row.BeginTime;
            EndTime = row.EndTime;
            AllowAdmitQuestions = row.AllowAdmitQuestions;
            ShowTestResult = row.ShowTestResult;
            ShowDetailsTestResult = row.ShowDetailsTestResult;
            ShowRightAnswersCount = row.ShowRightAnswersCount;
            IsActive = row.IsActive;
            IsMasterTest = row.IsMasterTest;
            AdaptiveMode = row.AdaptiveMode;
            IsDeleted = row.IsDeleted;
        }
    }
}

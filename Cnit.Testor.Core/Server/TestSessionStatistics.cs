using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cnit.Testor.Core.Server
{
    [DataContract]
    public sealed class TestSessionStatistics
    {
        [DataMember]
        public int RowNumber { get; set; }
        [DataMember]
        public int TestSessionId { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int TestId { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public double? Score { get; set; }
        [DataMember]
        public double? MaxScore { get; set; }
        [DataMember]
        public double? PassingScore { get; set; }
        [DataMember]
        public TimeSpan? TestTime { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public string StudNumber { get; set; }
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public string TestName { get; set; }
        [DataMember]
        public bool IsPassed { get; set; }
        [DataMember]
        public bool ShowTestResult { get; set; }
        [DataMember]
        public string IPAddress { get; set; }
		[DataMember]
		public double? Percent{ get; set; }
		[DataMember]
		public short Mark{ get; set; }

        public string StrTestTime
        {
            get
            {
                if (TestTime.HasValue)
                    return string.Format("{0:00}:{1:00}", (int)TestTime.Value.TotalHours, TestTime.Value.Minutes);
                else
                    return String.Empty;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cnit.Testor.Core.Server
{
    [Serializable]
    [DataContract]
    public sealed class StartTestParams
    {
        [DataMember]
        public int TestId { get; set; }

        [DataMember]
        public DateTime StartTime { get; set; }

        [DataMember]
        public TimeSpan RemaningTime { get; set; }

        [DataMember]
        public int[] QuestIds { get; set; }

        [DataMember]
        public int[] AnsIds { get; set; }

        [DataMember]
        public double MaxScore { get; set; }

        [DataMember]
        public TestorData TestSettings { get; set; }

        [DataMember]
        public int CurrentScore { get; set; }

        [DataMember]
        public string UniqId { get; set; }

        [DataMember]
        public int? AdditionalTime { get; set; }
    }
}

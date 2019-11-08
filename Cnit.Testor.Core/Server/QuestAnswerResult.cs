using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cnit.Testor.Core.Server
{
    [DataContract] 
    public sealed class QuestAnswerResult
    {
        [DataMember]
        public double Score { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public bool? isRightAnswer { get; set; }
    }
}

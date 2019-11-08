using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cnit.Testor.Core.Server
{
    [DataContract]
    public sealed class AppealResult
    {
        [DataMember]
        public TestorData TestorData { get; set; }
        [DataMember]
        public string Answer { get; set; }
        [DataMember]
        public bool IsRightAnswer { get; set; }
    }
}

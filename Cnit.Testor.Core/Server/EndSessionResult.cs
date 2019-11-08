using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cnit.Testor.Core.Server
{
    [DataContract]
    public sealed class EndSessionResult
    {
        [DataMember]
        public DateTime EndTime { get; set; }
        [DataMember]
        public int SessionId { get; set; }
    }
}

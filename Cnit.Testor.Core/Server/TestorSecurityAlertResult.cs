using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cnit.Testor.Core.Server
{
    [Serializable]
    [DataContract]
    public sealed class TestorSecurityAlertResult
    {
        public bool ShowAlert { get; set; }
        public string UniqId { get; set;}
    }
}

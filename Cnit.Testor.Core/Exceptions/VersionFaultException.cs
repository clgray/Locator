using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cnit.Testor.Core
{
    [DataContract]
    public class VersionFaultException
    {
        private string _exMessage;

        [DataMember]
        public string ExMessage
        {
            get { return _exMessage; }
            set { _exMessage = value; }
        }
    }
}

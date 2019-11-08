using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cnit.Testor.Core
{
    [DataContract]
    public enum TestorUserStatus
    {
        [EnumMember]
        NotActivated = 0,
        [EnumMember]
        InetUser = 1,
        [EnumMember]
        Removed = 2,
        [EnumMember]
        LocalNetUser = 3,
        [EnumMember]
        Any = 4
    }
}

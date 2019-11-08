using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cnit.Testor.Core
{
    [DataContract]
    public enum TestorItemType
    {
        [EnumMember]
        Test=0,
        [EnumMember]
        MasterTest = 1,
        [EnumMember]
        Folder=2,
        [EnumMember]
        Group=3
    }
}

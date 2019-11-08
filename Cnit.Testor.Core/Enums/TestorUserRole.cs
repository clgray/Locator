using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cnit.Testor.Core
{
    [DataContract]
    public enum TestorUserRole
    {
        [EnumMember]
        Anonymous = -1,
        [EnumMember]
        NotDefined = 0,
        [EnumMember]
        Student = 1,
        [EnumMember]
        Laboratorian = 2,
        [EnumMember]
        Teacher = 3,
        [EnumMember]
        Administrator = 4
    }
}

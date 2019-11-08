using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cnit.Testor.Core
{
    [DataContract]
    public enum TestingServerItemType
    {
        [EnumMember]
        None,
        [EnumMember]
        TestTree,
        [EnumMember]
        GroupTree,
        [EnumMember]
        FolderTree,
        [EnumMember]
        ActiveTestTree
    }
}

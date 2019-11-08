using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnit.Testor.Core
{
    public enum LogEventCodes
    {
        SessionDeleted = 0,
        GetDatabaseNamesList = 1,
        GetDatabasePassword = 2,
        WrongUserNameOrPassword = 3,
        ChangeSessionScore = 4
    }
}

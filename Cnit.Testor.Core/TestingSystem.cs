using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnit.Testor.Core
{
    public static class TestingSystem
    {
        private static Version _protocolVersion;
        private static string _displayName;

        public const string LocatorVersion = "3.20";

        public static Version ProtocolVersion
        {
            get
            {
                return _protocolVersion;
            }
        }

        public static string ProtocolVersionString
        {
            get
            {
                return _protocolVersion.ToString();
            }
        }

        public static string DisplayName
        {
            get
            {
                return _displayName;
            }
        }

        static TestingSystem()
        {
            _protocolVersion = new Version(8, 0, 0, 0);
            _displayName = "\"Локатор\"";
        }
    }
}

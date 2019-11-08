using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnit.Testor.Core
{
    public static class SystemProperties
    {
        public const string ANONYMOUS_POLICY = "AnonymousPolicy";
        public const string SMTP_FROM = "SmtpFrom";
        public const string SMTP_SERVER = "SmtpServer";
        public const string SMTP_LOGIN = "SmtpLogin";
        public const string SMTP_PASSWORD = "SmtpPassword";

        public const string SESSION_ALLOW_INTRANET = "AllowIntranet";
        public const string SESSION_ALLOW_PUBLIC = "AllowPublic";
        public const string SESSION_LOCAL_NETWORKS = "LocalNetworks";
        public const string SESSION_FALSE = "false";
        public const string SESSION_TRUE = "true";

        public const string REGISTER_MAIL = "RegMail";
        public const string RESTORE_MAIL = "RestoreMail";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core;

namespace CoreWebClient
{
    [Serializable]
    public class LocalUser
    {
        public const string SESSION_LOCAL_USER = "LocalUser";

        private bool _isIntranet;
        private WebServerProvider _webServerProvider;

        public static LocalUser CurrentUser
        {
            get
            {
                LocalUser context = (LocalUser)HttpContext.Current.Items[SESSION_LOCAL_USER];
                if (context == null)
                {
                    context = new LocalUser();
                    HttpContext.Current.Items[SESSION_LOCAL_USER] = context;
                }
                return (LocalUser)context;
            }
        }

        public static TestorSecurityProvider SecurityProvider
        {
            get
            {
                return CurrentUser._webServerProvider.SecurityProvider;
            }
        }

        public static ITestEdit TestEdit
        {
            get
            {
                return CurrentUser._webServerProvider.TestEdit;
            }
        }

        public static ITestClient TestClient
        {
            get
            {
                return CurrentUser._webServerProvider.TestClient;
            }
        }

        public static IUserManagement UserManagement
        {
            get
            {
                return CurrentUser._webServerProvider.UserManagement;
            }
        }

        public static IHelperService HelperService
        {
            get
            {
                return CurrentUser._webServerProvider.HelperService;
            }
        }

        public static WebServerProvider WebServerProvider
        {
            get
            {
                return CurrentUser._webServerProvider;
            }
        }

        public static bool IsIntranet
        {
            get
            {
                return CurrentUser._isIntranet;
            }
        }

        private LocalUser()
        {
            _isIntranet = IsIntranetTest();
            _webServerProvider = new WebServerProvider();
        }

        public static string GetPropertyValue(string property)
        {
            return CoreConfiguration.GetPropertyValue(property);
        }

        public static void SetPropertyValue(string property, string value)
        {
            CoreConfiguration.SetPropertyValue(property, value);
        }

        private bool IsIntranetTest()
        {
            if (CoreConfiguration.GetPropertyValue(SystemProperties.SESSION_ALLOW_INTRANET) == SystemProperties.SESSION_FALSE)
                return false;
            if (CoreConfiguration.GetPropertyValue(SystemProperties.SESSION_ALLOW_PUBLIC) == SystemProperties.SESSION_FALSE)
                return true;
            string userIP = HttpContext.Current.Request.UserHostAddress;
            string[] localNetworks = LocalUser.GetPropertyValue(SystemProperties.SESSION_LOCAL_NETWORKS).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var network in localNetworks)
                if (userIP.StartsWith(network))
                    return true;
            return false;
        }
    }
}

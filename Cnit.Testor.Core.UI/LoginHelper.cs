using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnit.Testor.Core.UI.Server.Login;
using System.Configuration;
using System.IO;

namespace Cnit.Testor.Core.UI
{
    public static class LoginHelper
    {
        public const int SEND_TIMEOUT = 20;

        private static bool _isFirstTime = true;

        public static string Server
        {
            get
            {
                return ConfigurationManager.AppSettings["server"];
            }
        }

        private static FileInfo _needOpen;

        public static FileInfo NeedOpen
        {
            get
            {
                return _needOpen;
            }
            set
            {
                _needOpen = value;
            }
        }

        public static SplashScreenForm Splash { get; set; }
        public static FirstTestForm FirstTF { get; set; }

        public static void AnonymousLogin()
        {
            LoginProvider provider = LoginProvider.AnonymousLogin(Server,
                new LoginProvider.LoginResultDelegate((hasPassword, errorMessage) =>
                {
                    TestingMainForm.CurrentForm.Invoke((Action)(() =>
                    {
                        if (hasPassword)
                        {
                            if (!_isFirstTime)
                                return;
                            _isFirstTime = false;
                            Splash.Close();
                            TestingMainForm.CurrentForm.ShowMainForm();
                            FirstTF.MdiParent = TestingMainForm.CurrentForm;
                            FirstTF.Show();
                        }
                        else
                        {
                            Splash.Close();
                            SystemMessage.ShowServerErrorMessage(errorMessage);
                            TestingMainForm.CurrentForm.Close();
                        }
                    }));
                }), SEND_TIMEOUT);
        }
    }
}

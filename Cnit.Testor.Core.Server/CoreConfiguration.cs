using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnit.Testor.Core.Server.Services;

namespace Cnit.Testor.Core.Server
{
    public static class CoreConfiguration
    {
        private static Dictionary<string, string> _properties = new Dictionary<string, string>();

        public static void TryConfiguration()
        {
            if (_properties.Count == 0)
                SetInitalConfiguration();
        }

        public static void SetInitalConfiguration()
        {
            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                dataContext.SystemSettings.DeleteAllOnSubmit(dataContext.SystemSettings);
                //---------------------------------------------------------------
                SystemSetting anonymousPolicy = new SystemSetting();
                anonymousPolicy.PropertyName = SystemProperties.ANONYMOUS_POLICY;
                anonymousPolicy.PropertyValue = "-1";
                dataContext.SystemSettings.InsertOnSubmit(anonymousPolicy);
                //---------------------------------------------------------------
                SystemSetting smtpFrom = new SystemSetting();
                smtpFrom.PropertyName = SystemProperties.SMTP_FROM;
                smtpFrom.PropertyValue = "support@localhost.ru";
                dataContext.SystemSettings.InsertOnSubmit(smtpFrom);
                //---------------------------------------------------------------
                SystemSetting smtpServer = new SystemSetting();
                smtpServer.PropertyName = SystemProperties.SMTP_SERVER;
                smtpServer.PropertyValue = "mail.localhost.ru";
                dataContext.SystemSettings.InsertOnSubmit(smtpServer);
                //---------------------------------------------------------------
                SystemSetting smtpLogin = new SystemSetting();
                smtpLogin.PropertyName = SystemProperties.SMTP_LOGIN;
                smtpLogin.PropertyValue = "login@localhost.ru";
                dataContext.SystemSettings.InsertOnSubmit(smtpLogin);
                //---------------------------------------------------------------
                SystemSetting smtpPassword = new SystemSetting();
                smtpPassword.PropertyName = SystemProperties.SMTP_PASSWORD;
                smtpPassword.PropertyValue = "password";
                dataContext.SystemSettings.InsertOnSubmit(smtpPassword);
                //---------------------------------------------------------------
                SystemSetting allowIntranet = new SystemSetting();
                allowIntranet.PropertyName = SystemProperties.SESSION_ALLOW_INTRANET;
                allowIntranet.PropertyValue = SystemProperties.SESSION_TRUE;
                dataContext.SystemSettings.InsertOnSubmit(allowIntranet);
                //---------------------------------------------------------------       
                SystemSetting allowPublic = new SystemSetting();
                allowPublic.PropertyName = SystemProperties.SESSION_ALLOW_PUBLIC;
                allowPublic.PropertyValue = SystemProperties.SESSION_TRUE;
                dataContext.SystemSettings.InsertOnSubmit(allowPublic);
                //---------------------------------------------------------------
                SystemSetting localNetworks = new SystemSetting();
                localNetworks.PropertyName = SystemProperties.SESSION_LOCAL_NETWORKS;
                localNetworks.PropertyValue = "192.168.;10.;127.0";
                dataContext.SystemSettings.InsertOnSubmit(localNetworks);
                //---------------------------------------------------------------
                SystemSetting regMail = new SystemSetting();
                regMail.PropertyName = SystemProperties.REGISTER_MAIL;
                regMail.PropertyValue = "Ваш логин: {0}\nДля активации аккаунта пройдите по ссылке: {1}";
                dataContext.SystemSettings.InsertOnSubmit(regMail);
                //---------------------------------------------------------------
                SystemSetting restoreMail = new SystemSetting();
                restoreMail.PropertyName = SystemProperties.RESTORE_MAIL;
                restoreMail.PropertyValue = "Ваш логин: {0}\nДля восстановления пароля пройдите по ссылке: {1}";
                dataContext.SystemSettings.InsertOnSubmit(restoreMail);
                //---------------------------------------------------------------
                TestorCoreUser admin = new TestorCoreUser()
                {
                    Birthday = DateTime.Now,
                    Email = "",
                    FirstName = "Администратор",
                    LastName = "Системный",
                    Login = "Administrator",
                    Password = "Password",
                    Sex = true,
                    Status = TestorUserStatus.InetUser,
                    StudNumber = String.Empty,
                    UserRole = TestorUserRole.Administrator,
                    UserGroups = new TestorTreeItem[] { }
                };
                User testorUser = new User();
                UserManagement um = new UserManagement();
                um.SetUserSettings(testorUser, admin, true, true, dataContext);
                testorUser.UserRole = (short)TestorUserRole.Administrator;
                testorUser.Status = (short)TestorUserStatus.InetUser;
                if (dataContext.Users.Where(c => c.Login == admin.Login).Count() == 0)
                    dataContext.Users.InsertOnSubmit(testorUser);
                dataContext.SubmitChanges();
            }
        }

        public static void LoadConfiguration()
        {
            _properties.Clear();
            DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString);
            var props = from c in dataContext.SystemSettings
                        select new { c.PropertyName, c.PropertyValue };
            foreach (var prop in props)
                _properties.Add(prop.PropertyName, prop.PropertyValue);
        }

        static CoreConfiguration()
        {
            LoadConfiguration();
            if (_properties.Count == 0)
            {
                SetInitalConfiguration();
                LoadConfiguration();
            }
        }

        public static bool GetAnonymousPolicy(ref int folderId)
        {
            bool retValue = true;
            int policy = int.Parse(GetPropertyValue(SystemProperties.ANONYMOUS_POLICY));
            if (policy > 0)
            {
                retValue = true;
                folderId = policy;
            }
            else if (policy == -1)
                retValue = false;
            return retValue;
        }

        public static string GetPropertyValue(string property)
        {
            return _properties[property];
        }

        public static void SetPropertyValue(string property, string value)
        {
            DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString);
            dataContext.SystemSettings.Where(c => c.PropertyName == property).First().PropertyValue = value;
            dataContext.SubmitChanges();
            _properties[property] = value;
        }
    }
}

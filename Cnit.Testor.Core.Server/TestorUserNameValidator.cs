using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Security;

namespace Cnit.Testor.Core.Server
{
    public sealed class TestorUserNameValidator : UserNamePasswordValidator
    {
        private const string _anonymousUserName = null;

        public static string AnonymousUserName
        {
            get
            {
                return _anonymousUserName;
            }
        }

        public static string ExceptionMessage
        {
            get
            {
                return "Unknown Username or Incorrect Password";
            }
        }

        public static string AnonymousPassword
        {
            get
            {
                return null;
            }
        }

        public static User WebValidate(string userName, string password)
        {
            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                User user = dataContext.Users.Where(c => c.Login == userName && c.Password == password && c.Status != (short)TestorUserStatus.Removed).FirstOrDefault();
                
                if (user == null)
                {
                    SystemEventsLog logMessage = new SystemEventsLog();
                    logMessage.EventCode = (short)LogEventCodes.WrongUserNameOrPassword;
                    logMessage.EventTime = DateTime.Now;
                    logMessage.Login = userName;
                    logMessage.EventText = String.Format("Wrong UserName or Password. Password: {0}", password);
                    dataContext.SystemEventsLogs.InsertOnSubmit(logMessage);
                    dataContext.SubmitChanges();
                }

                return user;
            }
        }

        public override void Validate(string userName, string password)
        {
            if (null == userName || null == password)
                throw new ArgumentNullException();
            if (userName != AnonymousUserName && password != AnonymousPassword)
            {
                using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
                {
                    var users = dataContext.Users.Where(c => c.Login == userName && c.Status != (short)TestorUserStatus.Removed);
                    if (String.IsNullOrEmpty(password))
                        password = "{@#emptypassword#}";
                    if (users.Where(c => c.Password == password).Count() <= 0)
                    {
                        SystemEventsLog logMessage = new SystemEventsLog();
                        logMessage.EventCode = (short)LogEventCodes.WrongUserNameOrPassword;
                        logMessage.EventTime = DateTime.Now;
                        logMessage.Login = userName;
                        logMessage.EventText = String.Format("Wrong UserName or Password. Password: {0}", password);
                        dataContext.SystemEventsLogs.InsertOnSubmit(logMessage);
                        dataContext.SubmitChanges();
                        throw new SecurityTokenException(ExceptionMessage);
                    }
                }
            }
        }
    }
}

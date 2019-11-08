using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Cnit.Testor.Core.Server;
using System.ServiceModel.Security;
using System.ServiceModel;

namespace Cnit.Testor.Core.UI.Server.Login
{
    public class LoginProvider
    {
        public delegate void LoginResultDelegate(bool hasPassword, string errorMessage);

        private delegate void TestorLoginDelegate(int sendTimeOut, IServerProvider provider);
        private string _userName;
        private string _password;
        private string _server;
        private string _errorMessage;
        private LoginResultDelegate _callback;

        public bool HasPassword { get; set; }

        public static LoginProvider Login(string userName, string password, string server, int sendTimeOut, IServerProvider provider, LoginResultDelegate callback)
        {
            return new LoginProvider(userName, password, server, callback, sendTimeOut, provider);
        }

        public static LoginProvider LoginSync(string userName, string password, string server, int sendTimeOut, IServerProvider provider)
        {
            return new LoginProvider(userName, password, server, sendTimeOut, provider);
        }

        public static LoginProvider AnonymousLogin(string server, LoginResultDelegate callback, int sendTimeOut)
        {
            return new LoginProvider(TestorUserNameValidator.AnonymousUserName, TestorUserNameValidator.AnonymousPassword, server, callback, sendTimeOut, null);
        }

        private LoginProvider(string userName, string password, string server, int sendTimeOut, IServerProvider provider)
        {
            _userName = userName;
            _password = password;
            _server = server;
            InitCredintails(sendTimeOut, provider);
        }

        private LoginProvider(string userName, string password, string server, LoginResultDelegate callback, int sendTimeOut, IServerProvider provider)
        {
            _callback = callback;
            _userName = userName;
            _password = password;
            _server = server;
            TestorLoginDelegate icd = new TestorLoginDelegate(InitCredintails);
            icd.BeginInvoke(sendTimeOut, provider, new AsyncCallback((o) =>
            {
                _callback.Invoke(HasPassword, _errorMessage);
            }), null);
        }

        private void InitCredintails(int sendTimeOut, IServerProvider provider)
        {
            try
            {
                StaticServerProvider.Login(_userName, _password, _server, sendTimeOut, provider);
            }
            catch (FaultException<VersionFaultException> ex)
            {
                HasPassword = false;
                _errorMessage = ex.Detail.ExMessage;
                return;
            }
            catch (MessageSecurityException)
            {
                HasPassword = false;
                _errorMessage = "Неверное имя пользователя и/или пароль.";
                return;
            }
            catch (Exception ex)
            {
                HasPassword = false;
                _errorMessage = ex.Message;
                return;
            }
            HasPassword = true;
        }
    }
}

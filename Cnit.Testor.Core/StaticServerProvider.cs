using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Xml;
using System.ServiceModel.Security;
using System.ServiceModel.Channels;
using System.Reflection;
using System.Data;

namespace Cnit.Testor.Core.Server
{
    public static class StaticServerProvider
    {
        private static Binding _binding;
        private static string _prefix = "http://";
        private static bool _isLogin;
        private static string _userName;
        private static string _password;
        private static string _server;
        private static IServerProvider _provider;
        private static ChannelFactory<ITestEdit> _editFactory;
        private static ChannelFactory<ITestClient> _clientFactory;
        private static ChannelFactory<IUserManagement> _userFactory;
        private static ChannelFactory<IHelperService> _helperFactory;
        private static ITestEdit _testEdit;
        private static ITestClient _testClient;
        private static IUserManagement _userManagement;
        private static IHelperService _helperService;
        private static TestorCoreUser _currentUser;

        public static bool IsLogin
        {
            get
            {
                return _isLogin;
            }
        }

        public static TestorCoreUser CurrentUser
        {
            get
            {
                return _currentUser;
            }
        }

        public static string UserName
        {
            get
            {
                return _userName;
            }
        }

        public static string Server
        {
            get
            {
                return _server;
            }
        }

        public static ITestEdit TestEdit
        {
            get
            {
                if (!_isLogin)
                    return null;
                if (_provider != null)
                    return _provider.TestEdit;
				if (_editFactory == null || _testEdit == null)
                {
					_editFactory = new ChannelFactory<ITestEdit>(_binding, String.Format("{0}{1}/Services/TestEdit.svc", _prefix, _server));
                    _editFactory.Credentials.UserName.UserName = _userName;
                    _editFactory.Credentials.UserName.Password = _password;
                    _editFactory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode =
                           X509CertificateValidationMode.None;
                    _testEdit = _editFactory.CreateChannel();
                }
                return _testEdit;
            }
        }

		public static ITestClient TestClient
		{
			get
			{
				if (!_isLogin)
					return null;
				if (_provider != null)
					return _provider.TestClient;
				if (_clientFactory == null || _testClient == null)
				{
					 _clientFactory = new ChannelFactory<ITestClient>(
						_binding, String.Format("{0}{1}/Services/TestClient.svc", _prefix, _server));
					_clientFactory.Credentials.UserName.UserName = _userName;
					_clientFactory.Credentials.UserName.Password = _password;
					_clientFactory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode =
						   X509CertificateValidationMode.None;
					_testClient = new ProxyTestClient(_clientFactory);
				}
				return _testClient;
			}
		}

        public static IUserManagement UserManagement
        {
            get
            {
                if (!_isLogin)
                    return null;
                if (_provider != null)
                    return _provider.UserManagement;
				if (_userFactory == null || _userManagement == null)
                {
                    _userFactory = new ChannelFactory<IUserManagement>(
						_binding, String.Format("{0}{1}/Services/UserManagement.svc", _prefix, _server));
                    _userFactory.Credentials.UserName.UserName = _userName;
                    _userFactory.Credentials.UserName.Password = _password;
                    _userFactory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode =
                           X509CertificateValidationMode.None;
                    _userManagement = _userFactory.CreateChannel();
                }
                return _userManagement;
            }
        }

        public static IHelperService HelperService
        {
            get
            {
                if (_provider != null)
                    return _provider.HelperService;
				if (_helperFactory == null || _helperService == null)
                {
                    _helperFactory = new ChannelFactory<IHelperService>(
						_binding, String.Format("{0}{1}/Services/HelperService.svc", _prefix, _server));
                    _helperFactory.Credentials.UserName.UserName = _userName;
                    _helperFactory.Credentials.UserName.Password = _password;
                    _helperFactory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode =
                           X509CertificateValidationMode.None;
                    _helperService = _helperFactory.CreateChannel();
                }
                return _helperService;
            }
        }

        public static void Login(string userName, string password, string server, int sendTimeOut, IServerProvider provider)
        {
            if (_isLogin)
                return;
            NullClients();
            _provider = provider;
            if (provider != null)
            {
                if (!_provider.ValidateCurrentUser(userName, password))
                    throw new Exception("Неверное имя пользователя и/или пароль.");
            }
            else
            {
                _userName = userName;
                _password = password;
                _server = server.ToLower();
                if (_server[_server.Length - 1] == '/')
                    _server = _server.Remove(_server.Length - 1, 1);
				if (_server.StartsWith("http://"))
				{
					_binding = new WSHttpBinding(SecurityMode.Message);
					WSHttpBinding currentBinding = (_binding as WSHttpBinding);
					currentBinding.TransactionFlow = false;
					currentBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
					currentBinding.MaxBufferPoolSize = int.MaxValue;
					currentBinding.MaxReceivedMessageSize = int.MaxValue;
					currentBinding.ReaderQuotas.MaxArrayLength = int.MaxValue;
					currentBinding.SendTimeout = TimeSpan.FromSeconds(5);
					currentBinding.OpenTimeout = TimeSpan.FromHours(10);
					_prefix = "http://";
				}
				else
				{
					_binding = new NetTcpBinding(SecurityMode.TransportWithMessageCredential, true);
					NetTcpBinding currentBinding = (_binding as NetTcpBinding);
					currentBinding.TransactionFlow = false;
					currentBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
					currentBinding.MaxBufferPoolSize = int.MaxValue;
					currentBinding.MaxReceivedMessageSize = int.MaxValue;
					currentBinding.ReaderQuotas.MaxArrayLength = int.MaxValue;
					currentBinding.SendTimeout = TimeSpan.FromSeconds(5);
					currentBinding.OpenTimeout = TimeSpan.FromHours(10);
					_prefix = "net.tcp://";
				}
                if (_server.StartsWith(_prefix))
                    _server = _server.Replace(_prefix, String.Empty);
            }
            //---------------------------------------------------------------------------------------------------------
            _currentUser = HelperService.GetServerVersion(TestingSystem.ProtocolVersionString);
            if (provider == null)
                _binding.SendTimeout = TimeSpan.FromSeconds(sendTimeOut);
            _isLogin = true;
        }

        public static void NullClients()
        {
			try
			{
			    if (_helperFactory != null && _helperFactory.State != CommunicationState.Closed)
			        _helperFactory.Close();
			    if (_editFactory != null && _editFactory.State != CommunicationState.Closed)
			        _editFactory.Close();
			    if (_userFactory != null && _userFactory.State != CommunicationState.Closed)
			        _userFactory.Close();
			    if (_clientFactory != null && _clientFactory.State != CommunicationState.Closed)
			        _clientFactory.Close();
			}
			catch
			{
			}
			finally
			{
                _userFactory = null;
                _clientFactory = null;
                _editFactory = null;
                _helperFactory = null;
                _userManagement = null;
                _testClient = null;
                _testEdit = null;
                _helperService = null;
			}
        }

        public static void Logout()
        {
            if (!_isLogin)
                return;
            _isLogin = false;
            _binding = null;
            NullClients();
        }
    }
}

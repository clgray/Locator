using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cnit.Testor.Core.Server;
using Cnit.Testor.Core.Server.Services;
using Cnit.Testor.Core;
using System.Configuration;

namespace Cnit.Testor.Core.Server
{
    [Serializable]
    public class WebServerProvider : IServerProvider
    {
        [NonSerialized]
        private HttpContext _httpContext;
        private string _userName;

        public TestorSecurityProvider SecurityProvider
        {
            get
            {
                if (!String.IsNullOrEmpty(_userName))
                    return new TestorSecurityProvider(_userName);
                else
                {
                    if (_httpContext == null)
                        return new TestorSecurityProvider(HttpContext.Current);
                    else
                        return new TestorSecurityProvider(_httpContext);
                }
            }
        }

        public ITestEdit TestEdit
        {
            get
            {
                TestEdit testEdit = new TestEdit();
                testEdit.SetProvider(SecurityProvider);
                return testEdit;
            }
        }

        public ITestClient TestClient
        {
            get
            {
                TestClient testClient = new TestClient();
                testClient.SetProvider(SecurityProvider);
                return testClient;
            }
        }

        public IUserManagement UserManagement
        {
            get
            {
                UserManagement userManagement = new UserManagement();
                userManagement.SetProvider(SecurityProvider);
                return userManagement;
            }
        }

        public IHelperService HelperService
        {
            get
            {
                HelperService helperService = new HelperService();
                helperService.SetProvider(SecurityProvider);
                return helperService;
            }
        }

        public bool ValidateCurrentUser(string userName, string password)
        {
            return TestorUserNameValidator.WebValidate(userName, password) != null;
        }

        public WebServerProvider() { }

        public WebServerProvider(string userName)
        {
            _userName = userName;
        }

        public WebServerProvider(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }
    }
}

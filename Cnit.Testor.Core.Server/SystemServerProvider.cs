using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnit.Testor.Core.Server.Services;

namespace Cnit.Testor.Core.Server
{
    public class SystemServerProvider : IServerProvider
    {
        public ITestEdit TestEdit
        {
            get { return new TestEdit(); }
        }

        public ITestClient TestClient
        {
            get { return new TestClient(); }
        }

        public IUserManagement UserManagement
        {
            get { return new UserManagement(); }
        }

        public IHelperService HelperService
        {
            get { return new HelperService(); }
        }

        public bool ValidateCurrentUser(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}

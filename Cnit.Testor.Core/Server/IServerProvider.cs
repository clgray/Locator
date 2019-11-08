using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnit.Testor.Core.Server
{
    public interface IServerProvider
    {
        ITestEdit TestEdit { get; }
        ITestClient TestClient { get; }
        IUserManagement UserManagement { get; }
        IHelperService HelperService { get; }

        bool ValidateCurrentUser(string userName, string password);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Configuration;
using System.Web;
using System.ServiceModel.Channels;

namespace Cnit.Testor.Core.Server
{
    public class TestorSecurityProvider
    {
        private HttpContext _context;
        private TestorCoreUser _currentUser;

        private static string _connectionString;

        public static string ConnectionString
        {
            get
            {
                if (String.IsNullOrEmpty(_connectionString))
                {
                        var conn = ConfigurationManager.ConnectionStrings["TestingConnectionString"];
                    if(conn!=null)
                        _connectionString = ConfigurationManager.ConnectionStrings["TestingConnectionString"].ConnectionString;
                    else
                        _connectionString= @"Data Source=.\SQLExpress;Initial Catalog=Locator;Integrated Security=True";

                }
                return _connectionString;
            }
        }

        public TestorCoreUser CurrentUser
        {
            get
            {
                return _currentUser;
            }
        }

        public string ClientIP
        {
            get
            {
                if (ServiceSecurityContext.Current == null)
                    return _context.Request.UserHostAddress;
                else
                {
                    MessageProperties messageProperties = OperationContext.Current.IncomingMessageProperties;
                    RemoteEndpointMessageProperty endpointProperty = (RemoteEndpointMessageProperty)messageProperties[RemoteEndpointMessageProperty.Name];
                    return endpointProperty.Address;
                }
            }
        }

        private void SetAnonymousUser()
        {
            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                int userId = -1;
                if (_context != null)
                {
                    if (_context.Session["AnonymousCreatTime"] != null)
                    {
                        DateTime createTime = (DateTime)_context.Session["AnonymousCreatTime"];
                        if ((DateTime.Now - createTime).TotalHours > 2)
                        {
                            var anonymous = dataContext.AnonymousUsers.Where(c => c.AnonymousUserId == (int)_context.Session["AnonymousUserId"]).First();
                            anonymous.CreateTime = DateTime.Now;
                            dataContext.SubmitChanges();
                            _context.Session["AnonymousUserId"] = anonymous.AnonymousUserId;
                            _context.Session["AnonymousCreatTime"] = anonymous.CreateTime;
                        }
                    }
                    if (_context.Session["AnonymousUserId"] == null)
                    {
                        AnonymousUser anonymous = new AnonymousUser();
                        dataContext.AnonymousUsers.InsertOnSubmit(anonymous);
                        anonymous.CreateTime = DateTime.Now;
                        dataContext.AnonymousUsers.DeleteAllOnSubmit(dataContext.AnonymousUsers.Where(c => (DateTime.Now - c.CreateTime).TotalHours > 3));
                        dataContext.SubmitChanges();
                        _context.Session["AnonymousUserId"] = anonymous.AnonymousUserId;
                        _context.Session["AnonymousCreatTime"] = anonymous.CreateTime;
                    }
                    userId = (int)_context.Session["AnonymousUserId"];
                }
                _currentUser = new TestorCoreUser()
                {
                    Login = "Anonymous",
                    Status = TestorUserStatus.InetUser,
                    UserId = userId,
                    UserRole = TestorUserRole.Anonymous
                };
            }
        }

        private void SetUser(string login)
        {
            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                var users = UserSearchHelper.GetUsers(dataContext.Users.Where(c => c.Login == login), true);
                if (users.Length > 0)
                    _currentUser = users[0];
            }
        }

        public TestorSecurityProvider(string userName)
        {
            SetUser(userName);
        }

        public TestorSecurityProvider(HttpContext context)
        {
            _context = context;
            if (ServiceSecurityContext.Current == null)
            {
                if (!_context.User.Identity.IsAuthenticated)
                    SetAnonymousUser();
                else
                    SetUser(_context.User.Identity.Name);
            }
            else
            {
                if (ServiceSecurityContext.Current.PrimaryIdentity.Name == TestorUserNameValidator.AnonymousUserName)
                    SetAnonymousUser();
                else
                    SetUser(ServiceSecurityContext.Current.PrimaryIdentity.Name);
            }
        }

        public void TestRoles(params TestorUserRole[] roles)
        {
            foreach (var role in roles)
                if (_currentUser.UserRole == role)
                    return;
            ThrowAccessFaultException();
        }

        public void TestTreeAccess(int itemId)
        {
            bool hasAccess = CurrentUser.UserRole == TestorUserRole.Administrator;
            if (CurrentUser.UserRole == TestorUserRole.Teacher || CurrentUser.UserRole == TestorUserRole.Laboratorian)
            {
                using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
                {
                    int? uid = dataContext.GetTestItemOwner(itemId);
                    if (uid.HasValue && CurrentUser.UserId == uid)
                        hasAccess = true;
                }
            }
            if (!hasAccess)
                ThrowAccessFaultException();
        }

        public void TestCoreTestsAccess(int testId)
        {
            bool hasAccess = CurrentUser.UserRole == TestorUserRole.Administrator;
            if (CurrentUser.UserRole == TestorUserRole.Teacher || CurrentUser.UserRole == TestorUserRole.Laboratorian)
            {
                using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
                {
                    int? uid = dataContext.GetTestOwner(testId);
                    if (uid.HasValue && CurrentUser.UserId == uid)
                        hasAccess = true;
                }
            }
            if (!hasAccess)
                ThrowAccessFaultException();
        }


        public void ThrowAccessFaultException(string message)
        {
            AccessFaultException ex = new AccessFaultException()
            {
                ExMessage = message
            };
            throw new FaultException<AccessFaultException>(ex, new FaultReason(ex.ExMessage));
        }

        public void ThrowAccessFaultException()
        {
            ThrowAccessFaultException("Недостаточно прав для выполнения данной операции.");
        }
    }
}

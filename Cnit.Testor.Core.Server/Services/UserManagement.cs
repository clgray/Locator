using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Reflection;
using System.Diagnostics;
using Cnit.Testor.Core.Packaging;

namespace Cnit.Testor.Core.Server.Services
{
    [Serializable]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, AddressFilterMode = AddressFilterMode.Any)]
    public sealed class UserManagement : TestorServiceBase, IUserManagement
    {
        public TestorCoreUser CreateUser(TestorCoreUser user)
        {
            Provider.TestRoles(TestorUserRole.Anonymous, TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

            if (user.UserRole != TestorUserRole.Student && user.UserRole != TestorUserRole.NotDefined)
                Provider.ThrowAccessFaultException();

            return CreateSystemUser(user);
        }

        //Не является операцией сервиса
        public TestorCoreUser CreateSystemUser(TestorCoreUser user)
        {
            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                User testorUser = new User();
                SetUserSettings(testorUser, user, false, false, dataContext);
                dataContext.Users.InsertOnSubmit(testorUser);
                SetUserGroups(testorUser, user.UserGroups, dataContext);
                dataContext.SubmitChanges();
                return UserSearchHelper.GetUsers(dataContext.Users.Where(c => c == testorUser), true)[0];
            }
        }

        public void SetUserGroups(int userId, TestorTreeItem[] groups)
        {
            Provider.TestRoles(TestorUserRole.Administrator);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                SetUserGroups(dataContext.Users.Where(c => c.UserId == userId).FirstOrDefault(), groups, dataContext);
                dataContext.SubmitChanges();
            }
        }

        //Не является операцией сервиса
        private void SetUserGroups(User user, TestorTreeItem[] groups, DataClassesTestorCoreDataContext dataContext)
        {
            if (user.UserId > 0)
                dataContext.UserGroups.DeleteAllOnSubmit(dataContext.UserGroups.Where(c => c.UserId == user.UserId));
            if (groups != null)
                foreach (var group in groups)
                {
                    UserGroup testorGroup = new UserGroup();
                    testorGroup.User = user;
                    testorGroup.GroupId = group.ItemId;
                    testorGroup.IsAdministrator = group.IsGroupAdmin;
                    user.UserGroups.Add(testorGroup);
                }
        }

        //Не является операцией сервиса
        internal void SetUserSettings(User testorUser, TestorCoreUser user, bool isUpdate, bool isAdminEdit, DataClassesTestorCoreDataContext dataContext)
        {
            testorUser.LastName = user.LastName;
            testorUser.FirstName = user.FirstName;
            testorUser.SecondName = user.SecondName;
            if (!isUpdate)
            {
                if (user.IsLocalUser && String.IsNullOrEmpty(user.Login))
                    testorUser.Login = Guid.NewGuid().ToString();
                else
                    testorUser.Login = user.Login;
                if (!String.IsNullOrEmpty(user.Password))
                    testorUser.Password = user.Password;
                else
                    testorUser.Password = "{@#emptypassword#}";
                if (user.IsLocalUser)
                    testorUser.Status = (short)TestorUserStatus.LocalNetUser;
                else
                    testorUser.Status = (short)TestorUserStatus.NotActivated;
                testorUser.UserRole = (short)TestorUserRole.Student;
            }
            else
            {
                testorUser.Status = (short)user.Status;
                if (isAdminEdit || Provider.CurrentUser.UserRole == TestorUserRole.Administrator)
                    testorUser.UserRole = (short)user.UserRole;
                if (testorUser.Login != user.Login)
                    testorUser.Login = user.Login;
                if (!String.IsNullOrEmpty(user.Password) && testorUser.Password != user.Password)
                    testorUser.Password = user.Password;
            }
            if (!String.IsNullOrEmpty(user.NewPassword) && isUpdate)
                testorUser.Password = user.NewPassword;
            testorUser.Email = user.Email;
            testorUser.Sex = user.Sex;
            testorUser.Birthday = user.Birthday;
            testorUser.StudNumber = user.StudNumber;
        }

        public void SetUserStatus(int userId, TestorUserStatus status)
        {
            Debug.Assert(userId > 0);

            Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                var user = dataContext.Users.Where(c => c.UserId == userId).FirstOrDefault();

                if (userId != Provider.CurrentUser.UserId)
                {
                    TestorUserRole alterRole = (TestorUserRole)user.UserRole;
                    if (Provider.CurrentUser.UserRole != TestorUserRole.Administrator && !(alterRole == TestorUserRole.Student || alterRole == TestorUserRole.Anonymous ||
                         alterRole == TestorUserRole.NotDefined))
                    {
                        Provider.ThrowAccessFaultException();
                        return;
                    }
                }
                user.Status = (short)status;
                dataContext.SubmitChanges();
            }
        }

        public TestorCoreUser AlterUser(TestorCoreUser user, bool alterGroups)
        {
            Debug.Assert(user.UserId > 0);

            Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                if (user.UserId <= 0)
                    return null;
                var testorUser = dataContext.Users.Where(c => c.UserId == user.UserId).FirstOrDefault();
                if (testorUser != null)
                {
                    TestorUserRole alterRole = (TestorUserRole)testorUser.UserRole;
                    if (user.UserId != Provider.CurrentUser.UserId)
                    {
                        if (Provider.CurrentUser.UserRole != TestorUserRole.Administrator && !(alterRole == TestorUserRole.Student || alterRole == TestorUserRole.Anonymous ||
                         alterRole == TestorUserRole.NotDefined))
                        {
                            Provider.ThrowAccessFaultException();
                            return null;
                        }
                    }
                    if (alterRole != user.UserRole && Provider.CurrentUser.UserRole != TestorUserRole.Administrator)
                        user.UserRole = alterRole;
                    SetUserSettings(testorUser, user, true, false, dataContext);
                    if (Provider.CurrentUser.UserRole == TestorUserRole.Administrator && alterGroups)
                        SetUserGroups(testorUser, user.UserGroups, dataContext);
                    dataContext.SubmitChanges();
                }
                return UserSearchHelper.GetUser(testorUser);
            }
        }

        public void RemoveUser(int userId)
        {
            Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

            if (userId != Provider.CurrentUser.UserId)
                SetUserStatus(userId, TestorUserStatus.Removed);
        }

        public byte[] FindUsers(string userInfo, TestorUserRole userRole, TestorUserStatus userStatus, bool getRemoved, int groupId, int takeCount)
        {
            if (Provider.CurrentUser.UserRole == TestorUserRole.NotDefined || Provider.CurrentUser.UserRole == TestorUserRole.Anonymous ||
                Provider.CurrentUser.UserRole == TestorUserRole.Student)
            {
                if (userRole != TestorUserRole.NotDefined && userRole != TestorUserRole.Anonymous &&
                    userRole != TestorUserRole.Student)
                    Provider.ThrowAccessFaultException();
            }

            return DataCompressor.CompressData<TestorCoreUser[]>(UserSearchHelper.FindUsers(userInfo, userRole, userStatus, groupId, getRemoved, takeCount, true));
        }

        public TestorTreeItem[] GetUserGroups(int userId)
        {
            if (userId != Provider.CurrentUser.UserId)
                Provider.TestRoles(TestorUserRole.Administrator, TestorUserRole.Teacher, TestorUserRole.Laboratorian);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                var groups = from c in dataContext.GetUserGroups(userId)
                             select new TestorTreeItem
                             {
                                 ItemId = c.GroupId,
                                 ItemType = TestorItemType.Group,
                                 ItemName = c.GroupName,
                                 IsGroupAdmin = c.IsAdministrator
                             };
                return groups.ToArray();
            }
        }
    }
}

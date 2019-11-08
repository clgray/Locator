using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Cnit.Testor.Core.Packaging;

namespace Cnit.Testor.Core.Server
{
    /// <summary>
    /// Поиск пользователей в базе данных
    /// </summary>
    public static class UserSearchHelper
    {
        /// <summary>
        /// Поиск пользователей в базе данных
        /// </summary>
        /// <param name="userInfo">Строка шаблона поиска. Через пробел задаются нужное кол-во букв фамилии имени и отчества</param>
        /// <param name="userRole">Определяет роль пользователей, внутри которой произволится поиск. В случае TestorUserRole.NotDefined роль не имеет значения</param>
        /// <param name="userStatus">Статус пользователя. В случае TestorUserStatus.Any ствтус не имеет значения</param>
        /// <param name="takeCount">Кол-во извлекаемых записей о пользователях. Если передаётся 0, то извлекаются все записи</param>
        /// <param name="getDetails">Получать ли подробную информацию о пользователе</param>
        /// <returns>Массив данных о пользователях</returns>
        public static TestorCoreUser[] FindUsers(string userInfo, TestorUserRole userRole,
            TestorUserStatus userStatus, int takeCount, bool getDetails)
        {
            Debug.Assert(userInfo != null);

            return FindUsers(userInfo, userRole, userStatus, 0, false, takeCount, getDetails);
        }

        /// <summary>
        /// Поиск пользователей в базе данных
        /// </summary>
        /// <param name="userInfo">Строка шаблона поиска. Через пробел задаются нужное кол-во букв фамилии имени и отчества</param>
        /// <param name="userRole">Определяет роль пользователей, внутри которой произволится поиск. В случае TestorUserRole.NotDefined роль не имеет значения</param>
        /// <param name="userStatus">Статус пользователя. В случае TestorUserStatus.Any ствтус не имеет значения</param>
        /// <param name="groupId">В случае, если параметр не равен нулю, поиск производится внутри группы</param>
        /// <param name="getRemoved">Искать ли только среди активных пользователей или только среди удалёных</param>
        /// <param name="takeCount">Кол-во извлекаемых записей о пользователях. Если передаётся 0, то извлекаются все записи</param>
        /// <param name="getDetails">Получать ли подробную информацию о пользователе</param>
        /// <returns>Массив данных о пользователях</returns>
        public static TestorCoreUser[] FindUsers(string userInfo, TestorUserRole userRole,
            TestorUserStatus userStatus, int groupId, bool getRemoved, int takeCount, bool getDetails)
        {
            Debug.Assert(userInfo != null);

            string[] names = userInfo.Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string fname = String.Empty;
            string lName = String.Empty;
            string sName = String.Empty;
            if (names.Length >= 1)
                lName = names[0];
            if (names.Length >= 2)
                fname = names[1];
            if (names.Length >= 3)
                sName = names[2];

            return FindUsers(lName, fname, sName, userRole, userStatus, groupId, getRemoved, takeCount, getDetails);
        }

        /// <summary>
        /// Поиск в базе первых десяти локальных студентов, удовлетворяющихшаблону поиска.
        /// </summary>
        /// <param name="userInfo">Строка шаблона поиска. Через пробел задаются нужное кол-во букв фамилии имени и отчества</param>
        /// <returns>Массив данных о пользователях</returns>
        public static TestorCoreUser[] FindTenLocalStudents(string userInfo)
        {
            Debug.Assert(userInfo != null);

            return FindUsers(userInfo, TestorUserRole.Student, TestorUserStatus.LocalNetUser, 0, false, 100, false);
        }

        /// <summary>
        /// Поиск в базе всех локальных студентов, удовлетворяющихшаблону поиска.
        /// </summary>
        /// <param name="userInfo">Строка шаблона поиска. Через пробел задаются нужное кол-во букв фамилии имени и отчества</param>
        /// <returns>Массив данных о пользователях</returns>
        public static TestorCoreUser[] FindAllLocalStudents(string userInfo)
        {
            Debug.Assert(userInfo != null);

            return FindUsers(userInfo, TestorUserRole.Student, TestorUserStatus.LocalNetUser, 0, false, 0, false);
        }

        /// <summary>
        /// Поиск пользователей в базе данных
        /// </summary>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <param name="secondName">Отчество</param>
        /// <param name="userRole">Определяет роль пользователей, внутри которой произволится поиск. В случае TestorUserRole.NotDefined роль не имеет значения</param>
        /// <param name="userStatus">Статус пользователя. В случае TestorUserStatus.Any ствтус не имеет значения</param>
        /// <param name="groupId">В случае, если параметр не равен нулю, поиск производится внутри группы</param>
        /// <param name="getRemoved">Искать ли только среди активных пользователей или только среди удалёных</param>
        /// <param name="takeCount">Кол-во извлекаемых записей о пользователях. Если передаётся 0, то извлекаются все записи</param>
        /// <param name="getDetails">Получать ли подробную информацию о пользователе</param>
        /// <returns>Массив данных о пользователях</returns>
        public static TestorCoreUser[] FindUsers(string lastName, string firstName, string secondName,
            TestorUserRole userRole, TestorUserStatus userStatus, int groupId, bool getRemoved, int takeCount, bool getDetails)
        {
            Debug.Assert(lastName != null);
            Debug.Assert(firstName != null);
            Debug.Assert(secondName != null);

            using (DataClassesTestorCoreDataContext dataContext = new DataClassesTestorCoreDataContext(TestorSecurityProvider.ConnectionString))
            {
                IQueryable<User> retValue = null;
                if (groupId > 0)
                {
                    retValue = from c in dataContext.UserGroups
                               join usr in dataContext.Users
                               on c.UserId equals usr.UserId
                               where c.GroupId == groupId
                               select usr;
                }
                else
                {
                    retValue = from c in dataContext.Users
                               where
                               c.LastName.StartsWith(lastName) && c.FirstName.StartsWith(firstName) && c.SecondName.StartsWith(secondName)
                               select c;
                }

                if (userRole != TestorUserRole.NotDefined)
                    retValue = retValue.Where(c => c.UserRole == (short)userRole);

                if (userStatus != TestorUserStatus.Any)
                    retValue = retValue.Where(c => c.UserRole == (short)userRole);

                if (!getRemoved)
                    retValue = retValue.Where(c => c.Status != (short)TestorUserStatus.Removed);
                else
                    retValue = retValue.Where(c => c.Status == (short)TestorUserStatus.Removed);

                if (takeCount != 0)
                    retValue = retValue.Take(takeCount);

                retValue = from c in retValue
                           orderby c.LastName, c.FirstName
                           select c;

                return GetUsers(retValue, getDetails);
            }
        }

        /// <summary>
        /// Получить из IQueryable<User> массив TestorCoreUser[]
        /// </summary>
        /// <param name="users">Пользователи</param>
        /// <returns>Массив пользователей</returns>
        public static TestorCoreUser[] GetUsers(IQueryable<User> users, bool getDetails)
        {
            List<TestorCoreUser> retValue = new List<TestorCoreUser>();
            foreach (var user in users)
            {
                if (getDetails)
                    retValue.Add(GetDetailsUser(user));
                else
                    retValue.Add(GetUser(user));
            }
            return retValue.ToArray();
        }

        /// <summary>
        /// Получить из User объект TestorCoreUser
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Пользователь</returns>
        public static TestorCoreUser GetDetailsUser(User user)
        {
            var retValue = new TestorCoreUser()
            {
                UserId = user.UserId,
                LastName = user.LastName,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                Login = user.Login,
                Sex = user.Sex,
                Status = (TestorUserStatus)user.Status,
                UserRole = (TestorUserRole)user.UserRole,
                Email = user.Email,
                StudNumber = user.StudNumber,
                Birthday = user.Birthday.HasValue ? user.Birthday.Value : new DateTime(1900, 1, 1)
            };
            return retValue;
        }

        /// <summary>
        /// Получить из User объект TestorCoreUser
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Пользователь</returns>
        public static TestorCoreUser GetUser(User user)
        {
            var retValue = new TestorCoreUser()
            {
                UserId = user.UserId,
                LastName = user.LastName,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                StudNumber = user.StudNumber,
                Login = user.Login
            };
            return retValue;
        }
    }
}

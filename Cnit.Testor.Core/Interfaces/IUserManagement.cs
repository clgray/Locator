using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cnit.Testor.Core.Server;

namespace Cnit.Testor.Core
{
    [ServiceContract(Namespace = "http://testor.ru")]
    public interface IUserManagement
    {
        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        TestorCoreUser CreateUser(TestorCoreUser user);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        void SetUserGroups(int userId, TestorTreeItem[] groups);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        void SetUserStatus(int userId, TestorUserStatus status);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        TestorCoreUser AlterUser(TestorCoreUser user, bool alterGroups);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        void RemoveUser(int userId);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        byte[] FindUsers(string userInfo, TestorUserRole userRole, TestorUserStatus userStatus, bool getRemoved, int groupId, int takeCount);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        TestorTreeItem[] GetUserGroups(int userId);
    }
}

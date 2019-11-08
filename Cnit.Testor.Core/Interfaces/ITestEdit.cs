using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cnit.Testor.Core.Server;

namespace Cnit.Testor.Core
{
    [ServiceContract(Namespace = "http://testor.ru")]
    public interface ITestEdit
    {
        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        TestorTreeItem[] SendTests(byte[] testorData, int folderId, int[] groupIds);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        void RemoveItem(int itemId, TestingServerItemType itemType);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        void RenameItem(int itemId, string newName, TestingServerItemType itemType);
       
        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        void SetItemParent(int itemId, int newParent, TestingServerItemType itemType);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        byte[] GetTestSettings(int testId);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        int[] GetTestGroups(int testId);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        void SetTestGroups(int testId, int[] addGroups, int[] remGroups);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        void SetTestSettings(byte[] testSettings);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        TestorTreeItem CreateFolder(int parentId, string folderName);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        TestorTreeItem[] AddGroups(int parentId, TestorTreeItem[] groups);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        TestorTreeItem[] GetServerTree(int parentId, int levelsNumber, TestingServerItemType itemType);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        TestorTreeItem[] GetTestParents(int itemId);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        TestorMasterPart[] GetTestMasterParts(int testId);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
		void SetTestMasterParts(TestorMasterPart[] masterParts, int testId);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
		TestorTreeItem[] GetTestRequirements(int testId);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        void SetTestRequirements(TestorTreeItem[] testRequirements, int testId);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        byte[] GetTestHTML(int testId);

        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        void SetTestTreeItemActivity(int nodeId, bool isActive);
    }
}

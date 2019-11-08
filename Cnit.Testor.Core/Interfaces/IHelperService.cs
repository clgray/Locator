using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cnit.Testor.Core.Server;

namespace Cnit.Testor.Core
{
    [ServiceContract(Namespace = "http://testor.ru")]
    public interface IHelperService
    {
        [OperationContract]
        [FaultContract(typeof(VersionFaultException))]
        TestorCoreUser GetServerVersion(string clientVersion);
        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        string GetPropertyValue(string property);
        [FaultContract(typeof(AccessFaultException))]
        [OperationContract]
        void SetPropertyValue(string property, string value);
    }
}
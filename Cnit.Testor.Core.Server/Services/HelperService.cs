using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Reflection;

namespace Cnit.Testor.Core.Server.Services
{
    [Serializable]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, AddressFilterMode = AddressFilterMode.Any)]
    public sealed class HelperService : TestorServiceBase, IHelperService
    {
        public TestorCoreUser GetServerVersion(string clientVersion)
        {
            Version ver = new Version(clientVersion);
            if (ver.Major < TestingSystem.ProtocolVersion.Major)
            {
                VersionFaultException ex = new VersionFaultException()
                {
                    ExMessage = String.Format("Данная версия клиента не поддерживается сервером.\nОбновите клиент.\nВерсия сервера: \"{0}\".", TestingSystem.LocatorVersion)
                };
                throw new FaultException<VersionFaultException>(ex, new FaultReason(ex.ExMessage));
            }
            else if (ver.Major > TestingSystem.ProtocolVersion.Major)
            {
                VersionFaultException ex = new VersionFaultException()
                {
                    ExMessage = String.Format("Вы подключаетесь к более старой версии сервера.\nДанная версия сервера не поддерживается.\nВерсия сервера: \"{0}\".", TestingSystem.LocatorVersion)
                };
                throw new FaultException<VersionFaultException>(ex, new FaultReason(ex.ExMessage));
            }
            return Provider.CurrentUser;
        }

        public string GetPropertyValue(string property)
        {
            return CoreConfiguration.GetPropertyValue(property);
        }

        public void SetPropertyValue(string property, string value)
        {
            Provider.TestRoles(TestorUserRole.Administrator);
            CoreConfiguration.SetPropertyValue(property, value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Cnit.Testor.Core.Server;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;
using Cnit.Testor.Core.Server.Services;
using System.Diagnostics;

namespace Cnit.Testor.Core.Server
{
    public static class ServerHostProvider
    {
        private static ServiceHost editHost;
        private static ServiceHost clientHost;
        private static ServiceHost userHost;
        private static ServiceHost helperHost;

        public static void StartServer(int port, string dnsIdentity, bool isHttp)
        {
            string prefix;
            if (isHttp)
                prefix = "http://";
            else
                prefix = "net.tcp://";
            //---------------------------------------------------------------------------------
            try
            {
                CoreConfiguration.TryConfiguration();
            }
            catch (Exception ex)
            {
                SystemMessage.Log(ex);
            }
            //---------------------------------------------------------------------------------
            string editServiceUrl = String.Format("{0}localhost:{1}/Services/TestEdit.svc", prefix, port);
			string clientServiceUrl = String.Format("{0}localhost:{1}/Services/TestClient.svc", prefix, port);
			string userServiceUrl = String.Format("{0}localhost:{1}/Services/UserManagement.svc", prefix, port);
			string helperServiceUrl = String.Format("{0}localhost:{1}/Services/HelperService.svc", prefix, port);
            editHost = new ServiceHost(typeof(TestEdit));
            clientHost = new ServiceHost(typeof(TestClient));
            userHost = new ServiceHost(typeof(UserManagement));
            helperHost = new ServiceHost(typeof(HelperService));
            //----------------------------------------------------------
            Binding binding;
            if (isHttp)
            {
                binding = new WSHttpBinding(SecurityMode.Message, true);
                WSHttpBinding httpBinding = (binding as WSHttpBinding);
                httpBinding.TransactionFlow = false;
                httpBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
                httpBinding.ReaderQuotas.MaxArrayLength = int.MaxValue;
                httpBinding.MaxReceivedMessageSize = int.MaxValue;
                httpBinding.MaxBufferPoolSize = int.MaxValue;
            }
            else
            {
                binding = new NetTcpBinding(SecurityMode.TransportWithMessageCredential, true);
                NetTcpBinding tcpBinding = (binding as NetTcpBinding);
                tcpBinding.TransactionFlow = false;
                tcpBinding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
                tcpBinding.ReaderQuotas.MaxArrayLength = int.MaxValue;
                tcpBinding.MaxReceivedMessageSize = int.MaxValue;
                tcpBinding.MaxBufferPoolSize = int.MaxValue;
                tcpBinding.MaxConnections = 150000;
            }
            //----------------------------------------------------------
            //makecert.exe -n CN=localhost -ss My -pe -sky exchange -sr LocalMachine
            ServiceEndpoint editServiceEndpoint = editHost.AddServiceEndpoint(
                typeof(ITestEdit), binding, editServiceUrl);
            ServiceEndpoint clientServiceEndpoint = clientHost.AddServiceEndpoint(
                typeof(ITestClient), binding, clientServiceUrl);
            ServiceEndpoint userServiceEndpoint = userHost.AddServiceEndpoint(
                typeof(IUserManagement), binding, userServiceUrl);
            ServiceEndpoint helperServiceEndpoint = helperHost.AddServiceEndpoint(
                typeof(IHelperService), binding, helperServiceUrl);
            //----------------------------------------------------------
            EndpointAddress editEndpointAdd = new EndpointAddress(new Uri(editServiceUrl),
                EndpointIdentity.CreateDnsIdentity(dnsIdentity));
            editServiceEndpoint.Address = editEndpointAdd;
            EndpointAddress clientEndpointAdd = new EndpointAddress(new Uri(clientServiceUrl),
                EndpointIdentity.CreateDnsIdentity(dnsIdentity));
            clientServiceEndpoint.Address = clientEndpointAdd;
            EndpointAddress userEndpointAdd = new EndpointAddress(new Uri(userServiceUrl),
                EndpointIdentity.CreateDnsIdentity(dnsIdentity));
            userServiceEndpoint.Address = userEndpointAdd;
            EndpointAddress helperEndpointAdd = new EndpointAddress(new Uri(helperServiceUrl),
                EndpointIdentity.CreateDnsIdentity(dnsIdentity));
            helperServiceEndpoint.Address = helperEndpointAdd;
            //----------------------------------------------------------
            if (isHttp)
            {
                ServiceMetadataBehavior editServiceMetadataBehavior = new ServiceMetadataBehavior();
                editServiceMetadataBehavior.HttpGetUrl = new Uri(editServiceUrl);
                editServiceMetadataBehavior.HttpGetEnabled = true;
                editHost.Description.Behaviors.Add(editServiceMetadataBehavior);

                ServiceMetadataBehavior clientServiceMetadataBehavior = new ServiceMetadataBehavior();
                clientServiceMetadataBehavior.HttpGetUrl = new Uri(clientServiceUrl);
                clientServiceMetadataBehavior.HttpGetEnabled = true;
                clientHost.Description.Behaviors.Add(clientServiceMetadataBehavior);

                ServiceMetadataBehavior userServiceMetadataBehavior = new ServiceMetadataBehavior();
                userServiceMetadataBehavior.HttpGetUrl = new Uri(userServiceUrl);
                userServiceMetadataBehavior.HttpGetEnabled = true;
                userHost.Description.Behaviors.Add(userServiceMetadataBehavior);

                ServiceMetadataBehavior helperServiceMetadataBehavior = new ServiceMetadataBehavior();
                helperServiceMetadataBehavior.HttpGetUrl = new Uri(helperServiceUrl);
                helperServiceMetadataBehavior.HttpGetEnabled = true;
                helperHost.Description.Behaviors.Add(helperServiceMetadataBehavior);
            }
            //----------------------------------------------------------
            ServiceCredentials serviceCredintails = new ServiceCredentials();
            serviceCredintails.UserNameAuthentication.UserNamePasswordValidationMode =
                UserNamePasswordValidationMode.Custom;
            serviceCredintails.UserNameAuthentication.CustomUserNamePasswordValidator =
            new TestorUserNameValidator();
            serviceCredintails.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine,
                StoreName.My, X509FindType.FindBySubjectName, dnsIdentity);
            editHost.Description.Behaviors.Add(serviceCredintails);
            clientHost.Description.Behaviors.Add(serviceCredintails);
            userHost.Description.Behaviors.Add(serviceCredintails);
            helperHost.Description.Behaviors.Add(serviceCredintails);
            //----------------------------------------------------------
            editHost.Open();
            clientHost.Open();
            userHost.Open();
            helperHost.Open();
        }

        public static void StopServer()
        {
            if (editHost != null)
                editHost.Abort();
            if (clientHost != null)
                clientHost.Abort();
            if (userHost != null)
                userHost.Abort();
            if (helperHost != null)
                helperHost.Abort();
        }
    }
}

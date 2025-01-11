using Contracts.Interfaces;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using Formatter = Manager.Formatter;

namespace PublisherClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPublisher proxy;
            try
            {

                var binding = new NetTcpBinding(SecurityMode.Transport);
                binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;

                var address = new EndpointAddress(
                    new Uri("net.tcp://localhost:8080/Publisher"),
                    new X509CertificateEndpointIdentity(
                        CertificateManager.GetCertificateFromStorage(StoreName.TrustedPeople, StoreLocation.LocalMachine, "pubsubengine")));

                var factory = new ChannelFactory<IPublisher>(binding, address);

                string cltCertCN = Formatter.ParseName(WindowsIdentity.GetCurrent().Name);
                Console.WriteLine("Welcome {0}", cltCertCN);

                factory.Credentials.ClientCertificate.Certificate = CertificateManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, cltCertCN);
                factory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;
                factory.Credentials.ServiceCertificate.Authentication.CustomCertificateValidator = new ClientCertValidator();
                factory.Credentials.ServiceCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;

                proxy = factory.CreateChannel();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error establishing connection:");
                Console.WriteLine(e.Message);
                Console.WriteLine("Program will now terminate.");
                Console.ReadLine();
                return;
            }
        }
    }
}

using Contracts.Interfaces;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberClient
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var callback = new SubscriberCallback();
            //var context = new InstanceContext(callback);

            var binding = new NetTcpBinding(SecurityMode.Transport);
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;

            // Endpoint adresa servera
            var address = new EndpointAddress(new Uri("net.tcp://localhost:8081/Subscriber"),
                                              new X509CertificateEndpointIdentity(CertificateManager.GetCertificateFromStorage(StoreName.TrustedPeople, StoreLocation.LocalMachine, "pubsubengine")));

            // Kreiranje fabrike kanala sa Duplex komunikacijom
           // var factory = new DuplexChannelFactory<ISubscriber>(context, binding, address);

            string cltCertCN = Formatter.ParseName(WindowsIdentity.GetCurrent().Name);
            Console.WriteLine("Welcome {0}", cltCertCN);

            /*factory.Credentials.ClientCertificate.Certificate = CertificateManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, cltCertCN);
            factory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;
            factory.Credentials.ServiceCertificate.Authentication.CustomCertificateValidator = new ClientCertValidator();
            factory.Credentials.ServiceCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;

            var proxy = factory.CreateChannel();*/

        }
    }
}

using PubSubCore.Interfaces;
using PubSubCore.Models;
using PubSubServices;
using PubSubServices.PubSubServices;

namespace PubSubEngine.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Kreiraj PubSubEngine
            IPubSubService pubSubService = new PubSubManager();

            // Kreiraj Publisher-a
            var publisher1 = new Publisher("Publisher1", "CriticalAlarms");
            publisher1.RegisterWithEngine(pubSubService);

            // Kreiraj Subscriber-a
            var subscriber1 = new Subscriber("Subscriber1");
            subscriber1.Subscribe("CriticalAlarms", 80, 100, pubSubService);

            // Publisher šalje alarm
            var alarm = new Alarm
            {
                GeneratedAt = DateTime.Now,
                Message = "Critical system failure!",
                RiskLevel = 90
            };
            publisher1.Publish(alarm);

            // Simulacija kraja
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

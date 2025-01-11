using Contracts.Interfaces;
using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubServices
{
    public class Publisher : IPublisher
    {
        public string Id { get; private set; }
        private readonly string _topic;

        public Publisher(string id, string topic)
        {
            Id = id;
            _topic = topic;
        }

        public void RegisterWithEngine(IPubSubService service)
        {
            Console.WriteLine($"Publisher {Id} registering with engine...");
            service.RegisterPublisher(this);
        }

        public void Publish(Alarm alarm)
        {
            Console.WriteLine($"Publisher {Id} publishing alarm on topic {_topic}...");
            // Pretpostavljam da je alarm već validan.
        }
    }
}

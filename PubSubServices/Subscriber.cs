using Contracts.Interfaces;
using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubServices
{
    public class Subscriber : ISubscriber
    {
        public string Id { get; private set; }
        private readonly Dictionary<string, (int MinRisk, int MaxRisk)> _subscriptions;

        public Subscriber(string id)
        {
            Id = id;
            _subscriptions = new Dictionary<string, (int MinRisk, int MaxRisk)>();
        }

        public void Subscribe(string topic, int riskLevelMin, int riskLevelMax, IPubSubService service)
        {
            Console.WriteLine($"Subscriber {Id} subscribing to topic {topic} with risk levels {riskLevelMin}-{riskLevelMax}...");
            _subscriptions[topic] = (riskLevelMin, riskLevelMax);
            service.RegisterSubscriber(this);
        }

        public void ReceiveMessage(Alarm alarm)
        {
            Console.WriteLine($"Subscriber {Id} received alarm: {alarm.Message} (Risk: {alarm.RiskLevel})");
        }

        public void Unsubscribe(string topic)
        {
            if (_subscriptions.Remove(topic))
            {
                Console.WriteLine($"Subscriber {Id} unsubscribed from topic {topic}.");
            }
        }
    }
}

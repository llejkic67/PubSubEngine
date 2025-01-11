using Contracts.Interfaces;
using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubServices
{
    public class PubSubManager : IPubSubService
    {
        private readonly List<IPublisher> publishers = new();
        private readonly List<ISubscriber> subscribers = new();

        public void RegisterPublisher(IPublisher publisher)
        {
            publishers.Add(publisher);
        }

        public void RegisterSubscriber(ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void PublishMessage(string topic, Alarm alarm)
        {
            foreach (var subscriber in subscribers)
            {
                subscriber.ReceiveMessage(alarm);
            }
        }
    }
}

using PubSubCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubCore.Interfaces
{
    public interface IPubSubService
    {
        void RegisterPublisher(IPublisher publisher);
        void RegisterSubscriber(ISubscriber subscriber);
        void PublishMessage(string topic, Alarm alarm);
    }
}

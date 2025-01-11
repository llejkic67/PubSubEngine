using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IPubSubService
    {
        void RegisterPublisher(IPublisher publisher);
        void RegisterSubscriber(ISubscriber subscriber);
        void PublishMessage(string topic, Alarm alarm);
    }
}

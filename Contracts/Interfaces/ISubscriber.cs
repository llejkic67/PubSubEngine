using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface ISubscriber
    {
        string Id { get; }
        void Subscribe(string topic, int riskLevelMin, int riskLevelMax, IPubSubService service);
        void ReceiveMessage(Alarm alarm);
        void Unsubscribe(string topic);
    }
}

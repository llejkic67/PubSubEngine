using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IPublisher
    {
        string Id { get; }
        void Publish(Alarm alarm);
        void RegisterWithEngine(IPubSubService service);
    }
}

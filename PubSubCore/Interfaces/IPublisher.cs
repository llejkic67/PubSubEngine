using PubSubCore.Models;


namespace PubSubCore.Interfaces
{
    public interface IPublisher
    {
        string Id { get; }
        void Publish(Alarm alarm);
        void RegisterWithEngine(IPubSubService service);
    }
}

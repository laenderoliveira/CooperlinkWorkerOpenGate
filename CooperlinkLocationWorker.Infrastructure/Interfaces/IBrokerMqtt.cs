namespace CooperlinkLocationWorker.Infrastructure.Interfaces
{
    public interface IBrokerMqtt
    {
        void PublishMessageDefaultTopic(string message);
        void PublishMessage(string topic, string message);
    }
}

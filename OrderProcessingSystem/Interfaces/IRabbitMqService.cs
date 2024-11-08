namespace OrderProcessingSystem.Interfaces
{
    public interface IRabbitMqService
    {
        void PublishMessage<T>(string routingKey, T message);
    }
}

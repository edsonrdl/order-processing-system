namespace OrderProcessingSystem.RabbitMqService
{
    public interface IRabbitMqService
    {
        void PublishMessage<T>(string exchangeName, string routingKey, T message);
    }
}

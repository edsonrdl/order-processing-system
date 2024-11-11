namespace OrderProcessingSystem.RabbitMqService
{
    public interface IRabbitMqService
    {
        void PublishMessage<T>(string exchangeName, string queueName, string routingKey, T message);
    }
}

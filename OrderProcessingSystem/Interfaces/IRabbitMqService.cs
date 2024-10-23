namespace OrderProcessingSystem.Interfaces
{
    public interface IRabbitMqService
    {
        void PublishMessage(string routingKey, string message);
    }
}

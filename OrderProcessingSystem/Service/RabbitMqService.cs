using RabbitMQ.Client;
using System.Text;
using OrderProcessingSystem.Interfaces;

public class RabbitMqService : IRabbitMqService
{
    private readonly string exchangeName = "order_exchange";

    public void PublishMessage(string routingKey, string message)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Topic);

        var body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish(exchange: exchangeName, routingKey: routingKey, body: body);
    }
}

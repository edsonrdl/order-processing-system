using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using OrderProcessingSystem.RabbitMqService;

public class RabbitMqService : IRabbitMqService
{
    public void PublishMessage<T>(string exchangeName, string queueName, string routingKey, T message)
    {

        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            Port = 5672,
            UserName = "guest",
            Password = "guest",
            VirtualHost = "/",
            AutomaticRecoveryEnabled = true,
            NetworkRecoveryInterval = TimeSpan.FromSeconds(10)
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();


        channel.ExchangeDeclare(
         exchange: exchangeName, 
         type: "direct",         
         durable: true,
         autoDelete: false,
         arguments: null
        );

        string messageJson = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(messageJson);


        channel.QueueDeclare(
        queue: queueName,
        durable: true,
        exclusive: false,
        autoDelete: false,
        arguments: null
        );

       channel.QueueBind(queueName, exchangeName, routingKey);


        channel.BasicPublish(
        exchange: exchangeName,
        routingKey: routingKey,
        basicProperties: null,
        body: body
        );
    }
}

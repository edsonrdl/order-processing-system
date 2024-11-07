using RabbitMQ.Client;
using System.Text;
using OrderProcessingSystem.Interfaces;

public class RabbitMqService : IRabbitMqService
{
    public void PublishMessage(string queueName, string message)
    {
        // Configuração do ConnectionFactory com as propriedades desejadas
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

        // Estabelecendo conexão e canal com o RabbitMQ
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        // Declaração da fila para garantir que ela exista
        channel.QueueDeclare(
            queue: queueName, // Nome da fila específica
            durable: true, // A fila é persistente (sobrevive a reinicializações do servidor)
            exclusive: false, // Não é exclusiva para a conexão atual
            autoDelete: false, // Não será excluída quando o último consumidor se desconectar
            arguments: null // Sem argumentos adicionais
        );

        // Preparando a mensagem para envio
        var body = Encoding.UTF8.GetBytes(message);

        // Publicando a mensagem diretamente na fila especificada
        channel.BasicPublish(
            exchange: "", // Usar uma exchange vazia para enviar diretamente para a fila
            routingKey: queueName, // Nome da fila como chave de roteamento
            basicProperties: null,
            body: body
        );
    }
}

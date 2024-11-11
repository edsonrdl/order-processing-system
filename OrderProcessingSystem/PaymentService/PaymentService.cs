using OrderProcessingSystem.Dtos.PaymentDtos;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Enum;
using OrderProcessingSystem.RabbitMqService;

namespace OrderProcessingSystem.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly IRabbitMqService _rabbitMqService;

        public PaymentService(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        public void PublishPayment(PaymentModel payment)
        {
 
            string exchangeName = "service_exchange";

            string queue = "payment_queue";

            string routingKey = "order.payment";

            _rabbitMqService.PublishMessage(exchangeName,queue, routingKey, payment);
        }
    }
}

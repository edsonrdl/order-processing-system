using OrderProcessingSystem.Interfaces;

namespace OrderProcessingSystem.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IRabbitMqService _rabbitMqService;

        public PaymentService(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        public void ProcessPayment(string paymentDetails)
        {
            _rabbitMqService.PublishMessage("order.payment", paymentDetails);
        }
    }
}

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

        public void ProcessPayment(PaymentRequest payment)
        {
            string paymentDetails = GeneratePaymentMessage(payment);

            string exchangeName = "service_exchange";

            string routingKey = "order.payment";

            _rabbitMqService.PublishMessage(exchangeName,routingKey, paymentDetails);
        }

        private string GeneratePaymentMessage(PaymentRequest payment)
        {
            string statusMessage = payment.Status switch
            {
                PaymentStatusEnum.Pending => "Pagamento pendente.",
                PaymentStatusEnum.Processing => "Pagamento sendo processado.",
                PaymentStatusEnum.Completed => "Pagamento concluído.",
                PaymentStatusEnum.Cancelled => "Pagamento cancelado.",
                _ => "Status de pagamento desconhecido."
            };

            return $"Order ID: {payment.OrderId}, Status: {statusMessage}, Amount: {payment.Amount}, Payment Date: {payment.PaymentDate}";
        }
    }
}

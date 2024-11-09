using OrderProcessingSystem.Interfaces;
using OrderProcessingSystem.Dtos.PaymentDtos;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Enum;

namespace OrderProcessingSystem.Service
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
            // Validação ou lógica adicional pode ser aplicada aqui
            string paymentDetails = GeneratePaymentMessage(payment);

            // Publica a mensagem usando RabbitMQ
            _rabbitMqService.PublishMessage("order.payment", paymentDetails);
        }

        private string GeneratePaymentMessage(PaymentRequest payment)
        {
            string statusMessage = payment.Status switch
            {
                PaymentStatusEnum.Pending => "Pagamento pendente.",
                PaymentStatusEnum.Completed => "Pagamento concluído.",
                PaymentStatusEnum.Failed => "Pagamento falhou.",
                PaymentStatusEnum.Cancelled => "Pagamento cancelado.",
                _ => "Status de pagamento desconhecido."
            };

            return $"Order ID: {payment.OrderId}, Status: {statusMessage}, Amount: {payment.Amount}, Payment Date: {payment.PaymentDate}";
        }
    }
}

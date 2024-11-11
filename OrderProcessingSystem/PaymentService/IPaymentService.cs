using OrderProcessingSystem.Dtos.PaymentDtos;

namespace OrderProcessingSystem.PaymentService
{
    public interface IPaymentService
    {
        void ProcessPayment(PaymentRequest payment);
    }
}

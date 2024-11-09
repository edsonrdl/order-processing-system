using OrderProcessingSystem.Dtos.PaymentDtos;

namespace OrderProcessingSystem.Interfaces
{
    public interface IPaymentService
    {
        void ProcessPayment(PaymentRequest payment);
    }
}

using OrderProcessingSystem.Dtos.PaymentDtos;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.PaymentService
{
    public interface IPaymentService
    {
        void PublishPayment(PaymentModel paymentModel);
    }
}

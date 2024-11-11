using OrderProcessingSystem.Dtos.NotificationDtos;
using OrderProcessingSystem.Dtos.PaymentDtos;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Mapper.PaymentMapper
{
    public interface IPaymentMapper
    {
        PaymentModel MapToPaymentModel(PaymentRequest request);
    }
}
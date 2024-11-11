using OrderProcessingSystem.Dtos.NotificationDtos;
using OrderProcessingSystem.Dtos.PaymentDtos;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Mapper.PaymentMapper
{
    public class PaymentMapper : IPaymentMapper
    {
        public  PaymentModel MapToPaymentModel(PaymentRequest request)
        {
            return new PaymentModel
            {
                PaymentId = Guid.NewGuid(),
                OrderId = request.OrderId,
                Amount = request.Amount,
                Status = request.Status,
                PaymentDate = request.PaymentDate
            };
        }

    }
}

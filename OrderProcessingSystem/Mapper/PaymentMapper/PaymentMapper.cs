using OrderProcessingSystem.Dtos.NotificationDtos;
using OrderProcessingSystem.Dtos.PaymentDtos;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Mapper.PaymentMapper
{
    public class PaymentMapper : IPaymentMapper
    {
        public  PaymentModel MapToPaymentModel(PaymentRequest request)
        {
            if (request.Amount <= 0)
            {
                throw new ArgumentException("Valor do pagamento deve ser maior que zero.");
            }

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

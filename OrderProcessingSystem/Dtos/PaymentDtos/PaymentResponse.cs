using OrderProcessingSystem.Enum;
using System.ComponentModel.DataAnnotations;

namespace OrderProcessingSystem.Dtos.PaymentDtos
{
    public class PaymentResponse
    {

        public Guid OrderId { get; set; }
        public Decimal Amount { get; set; }
        public PaymentStatusEnum Status { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}

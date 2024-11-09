using OrderProcessingSystem.Enum;

namespace OrderProcessingSystem.Dtos.PaymentDtos
{
    public class PaymentRequest
    {
        public Guid OrderId { get; set; }
        public Decimal Amount { get; set; }
        public PaymentStatusEnum Status { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}

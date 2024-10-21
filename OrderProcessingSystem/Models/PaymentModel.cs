using OrderProcessingSystem.Enum;

namespace OrderProcessingSystem.Models
{
    public class PaymentModel
    {
        public Guid PaymentId { get; set; }
        public Guid OrderId { get; set; }
        public Decimal Amount { get; set; }
        public PaymentStatusEnum Status { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}

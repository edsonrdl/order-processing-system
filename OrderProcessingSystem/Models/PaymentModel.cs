using OrderProcessingSystem.Enum;
using System.ComponentModel.DataAnnotations;

namespace OrderProcessingSystem.Models
{
    public class PaymentModel
    {
        public Guid PaymentId { get; set; }

        [Required(ErrorMessage = "O código  do produto é obrigatório.")]
        public Guid OrderId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Valor do pagamento deve ser maior que zero.")]
        public Decimal Amount { get; set; }
        public PaymentStatusEnum Status { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}

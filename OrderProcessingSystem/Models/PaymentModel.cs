﻿using OrderProcessingSystem.Enum;
using System.ComponentModel.DataAnnotations;

namespace OrderProcessingSystem.Models
{
    public class PaymentModel
    {
        public Guid PaymentId { get; set; }

        [Required(ErrorMessage = "O código  do produto é obrigatório.")]
        public Guid OrderId { get; set; }
        public Decimal Amount { get; set; }
        public PaymentStatusEnum Status { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}

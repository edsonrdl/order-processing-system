﻿using System.ComponentModel.DataAnnotations;
using OrderProcessingSystem.Enum;

namespace OrderProcessingSystem.Models
{
    public class OrderModel
    {
        public Guid OrderId { get; set; }

        [Required(ErrorMessage = "Nome do produto é obrigatório.")]
        public string ProductName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "quantidade deve ser maior que zero.")]
        public int Quantity { get; set; }

        public OrderStatusEnum Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

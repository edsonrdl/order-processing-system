﻿using OrderProcessingSystem.Dtos.OrderDtos;
using OrderProcessingSystem.Dtos.PaymentDtos;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.UseCases.PaymentCreate
{
    public interface IPaymentCreate
    {
        void CreatePayment(PaymentRequest request);
    }
}

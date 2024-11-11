using OrderProcessingSystem.Dtos.PaymentDtos;
using OrderProcessingSystem.Mapper.NotificationMapper;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.PaymentService;

namespace OrderProcessingSystem.UseCases.PaymentCreate
{
    public class PaymentCreate : IPaymentCreate
    {
        readonly IPaymentService _paymentService;

        readonly PaymentMapper _paymentMapper;

        public PaymentCreate (IPaymentService paymentService, PaymentMapper paymentMapper)
        {
           this._paymentService = paymentService;
            this._paymentMapper = paymentMapper;
        }

        void IPaymentCreate.CreatePayment(PaymentRequest request)
        {
            try
            {
                PaymentModel paymentModel=this._paymentMapper.(request);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado :{ex.Message}");
                throw new ApplicationException("Ocorreu um erro inesperado ao processar o pagamento!", ex);
            }
        }
    }
}

using OrderProcessingSystem.Dtos.PaymentDtos;
using OrderProcessingSystem.Mapper.NotificationMapper;
using OrderProcessingSystem.Mapper.PaymentMapper;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.PaymentService;

namespace OrderProcessingSystem.UseCases.PaymentCreate
{
    public class PaymentCreate : IPaymentCreate
    {
        readonly IPaymentService _paymentService;

        readonly IPaymentMapper _paymentMapper;

        public PaymentCreate (IPaymentService paymentService, IPaymentMapper paymentMapper)
        {
           this._paymentService = paymentService;
            this._paymentMapper = paymentMapper;
        }

        void IPaymentCreate.CreatePayment(PaymentRequest request)
        {
            try
            {
                PaymentModel paymentModel=this._paymentMapper.MapToPaymentModel(request);
                Console.WriteLine(paymentModel);
                this._paymentService.PublishPayment(paymentModel);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado :{ex.Message}");
                throw new ApplicationException("Ocorreu um erro inesperado ao processar o pagamento!", ex);
            }
        }
    }
}

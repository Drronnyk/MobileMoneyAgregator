public interface IPaymentProvider
{
    Task<PaymentResultDto> InitialPayment (decimal amount, string phone );
}
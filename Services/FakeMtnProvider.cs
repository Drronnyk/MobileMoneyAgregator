using MobileMoneyAgregator.Helpers;

public class FakeMtnProvider : IPaymentProvider 
{
    public Task<PaymentResultDto> InitialPayment(decimal amount, string phone)
    {
        var payment = new PaymentResultDto
        {
            ReferencePayment = Guid.NewGuid().ToString(),
            TransactionStatus = StatusTransaction.Success
            
        };
        return Task.FromResult(payment);
    }
}
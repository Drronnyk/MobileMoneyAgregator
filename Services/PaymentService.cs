using MobileMoneyAgregator.Helpers;

public class PaymentService
{
    private readonly FakeMtnProvider _fakeMtnProvider;
    private readonly FakeOrangeProvider _fakeOrangeProvider;

    public PaymentService(FakeMtnProvider fakeMtnProvider, FakeOrangeProvider fakeOrangeProvider)
    {
        _fakeMtnProvider = fakeMtnProvider;
        _fakeOrangeProvider =  fakeOrangeProvider ;
    }
    public async Task<PaymentResultDto> InitiatePayment(EnumProvider provider, decimal amount, string phone)
    {
        switch (provider)
        {
            case EnumProvider.Mtn:
            return await _fakeMtnProvider.InitialPayment(amount,phone);
            case EnumProvider.Orange:
            return await _fakeOrangeProvider.InitialPayment(amount,phone);
            default:
            throw new ArgumentException("Provider Non Reconnu");
        }
    }


}
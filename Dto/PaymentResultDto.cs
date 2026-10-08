using MobileMoneyAgregator.Helpers;

public class PaymentResultDto
{
    public StatusTransaction TransactionStatus
    {
        get;
        set;
    }
    public string ReferencePayment
    {
        get;
        set;
    }=string.Empty;
}
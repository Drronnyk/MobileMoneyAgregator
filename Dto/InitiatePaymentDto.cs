using MobileMoneyAgregator.Helpers;

public class InitiatePaymentDto
{
    public decimal Amount
    {
        get;
        set;
    }
    public EnumProvider Provider
    {
        get;
        set;
    }
    public string PhoneNumber
    {
        get;
        set;

    }=string.Empty;

}
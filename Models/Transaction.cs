using MobileMoneyAgregator.Helpers;
using MobileMoneyAgregator.Models.Merchant;

public class Transaction
{
    public int Id { get; set; }

    public int MerchantId {  get; set; }
    public Merchant Merchant { get; set; } = null!;




    public decimal Montant {  get; set; }
    public string Devise {  get; set; }=string.Empty;
    public EnumProvider ProviderName {  get; set; }
    public StatusTransaction PaymentStatus {  get; set; }
    public string PhoneCustomer {  get; set; }=string.Empty;
    public DateTime DateCreation {  get; set; }
    public DateTime? DateConfirmation { get; set; }

 public ICollection<PaymentProviderLog> ProviderLogs
    {
        get;
        set;
    }=null!;

}
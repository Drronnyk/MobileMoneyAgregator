using MobileMoneyAgregator.Helpers;
using MobileMoneyAgregator.Models.Merchant;

public class Transaction
{
    public int Id { get; set; }

    public int MerchantId {  get; set; }
    public Merchant Merchant { get; set; } = null!;




    public double Montant {  get; set; }
    public string Devise {  get; set; }=string.Empty;
    public Provider ProviderName {  get; set; }
    public Status PayementStatus {  get; set; }
    public string PhoneCustomer {  get; set; }=string.Empty;
    public DateTime DateCreation {  get; set; }
    public DateTime? DateConfirmation { get; set; }

 public ICollection<PaymentProviderLog> ProviderLogs
    {
        get;
        set;
    }=null!;

}
using MobileMoneyAggregator.Helpers;

public class Transaction
{
    public int Id { get; set; }

    public int MerchantId {  get; set; }
    public Merchant Merchant { get; set; }! = null;




    public double Montant {  get; set; }
    public string Devise {  get; set; }
    public Provider ProviderName {  get; set; }
    public Status PayementStatus {  get; set; }
    public string PhoneCustomer {  get; set; }
    public DateTime DateCreation {  get; set; }
    public DateTime? DateConfirmation { get; set; }



}
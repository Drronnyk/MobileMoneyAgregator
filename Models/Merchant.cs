namespace MobileMoneyAgregator.Models.Merchant;
public class Merchant

{
    public int Id { get; set; }
    public string NameEnterprise { get; set; }=string.Empty;
    public string Email {  get; set; }=string.Empty;
    public string ApiKey {  get; set; }=string.Empty;
    public DateTime DateCreation {  get; set; }
    
    public string PasswordHash
    {
        get;
        set;
    }=string.Empty;

    public ICollection<Transaction> Transactions
    {
        get;
        set;
    }=null!;

}
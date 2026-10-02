public class PaymentProviderLog
{
	public int Id { get; set; }

	public int TransactionId { get; set; }
	public Transaction Transaction { get; set; }= null!;


	public string PayloadBrut {  get; set; }=string.Empty;
	public DateTime DateReception {  get; set; }


}
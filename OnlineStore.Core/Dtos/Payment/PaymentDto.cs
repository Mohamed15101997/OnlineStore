namespace OnlineStore.Core.Dtos.Payment
{
	public class PaymentDto
	{
		public string PaymentIntentId { get; set; }
		public string ClientSecret { get; set; }
		public int OrderId { get; set; }
	}
}

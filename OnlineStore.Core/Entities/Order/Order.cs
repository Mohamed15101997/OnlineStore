namespace OnlineStore.Core.Entities.Order
{
	public class Order : BaseEntity<int>
	{
		public Order()
		{
			
		}
		public Order(string buyerEmail, Address shippingAddress, DeliveryMethod deliveryMethod, ICollection<OrderItem> items, decimal subTotal, string paymentIntentId,string clientSecret)
		{
			BuyerEmail = buyerEmail;
			ShippingAddress = shippingAddress;
			DeliveryMethod = deliveryMethod;
			Items = items;
			SubTotal = subTotal;
			PaymentIntentId = paymentIntentId;
			ClientSecret = clientSecret;
		}

		public string BuyerEmail { get; set; }
		public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;
		public OrderStatus Status { get; set; } = OrderStatus.Pendeing;
		public Address ShippingAddress { get; set; }
		public DeliveryMethod DeliveryMethod { get; set; }
		public int DeliveryMethodId { get; set; }
		public ICollection<OrderItem> Items { get; set; }
		public decimal SubTotal { get; set; }
		public decimal GetTotal() => SubTotal + DeliveryMethod.Cost;
		public string PaymentIntentId { get; set; }
		public string ClientSecret { get; set; }
	}
}

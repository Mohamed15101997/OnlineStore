using OnlineStore.Core.Entities.Order;
using System.Security.Claims;

namespace OnlineStore.Core.Dtos.Orders
{
	public class CreateOrderDto
	{
		public string BasketId { get; set; }
		public int DeliveryMethodId { get; set; }
		public Address ShippingAddress { get; set; }
	}
}

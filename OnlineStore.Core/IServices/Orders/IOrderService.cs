using OnlineStore.Core.Entities.Order;
using System.Security.Claims;

namespace OnlineStore.Core.IServices.Orders
{
	public interface IOrderService
	{
		Task<Order> CreateOrderasync(ClaimsPrincipal user, string basketId, int deliveryMethodId, Address shippingAddress);
		Task<IEnumerable<Order?>> GetOrdersForUserAsync(ClaimsPrincipal user);
		Task<Order?> GetOrderByIdForUserAsync(ClaimsPrincipal user, int orderId);
		Task<Order?> GetOrderByPaymentIntentIdForUserAsync(string paymentIntentId);
	}
}

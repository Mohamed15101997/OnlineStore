using OnlineStore.Core.Dtos.Payment;
using OnlineStore.Core.Entities.Order;
using System.Security.Claims;

namespace OnlineStore.Core.IServices.Payment
{
	public interface IPaymentService
	{
		Task<PaymentDto> CreateOrUpdatePaymentIntentId(ClaimsPrincipal user,int orderId);
		Task<Order> UpdateOrderStatus(string paymentintentId , bool flag);
	}
}

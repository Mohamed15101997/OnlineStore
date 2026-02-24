using Microsoft.Extensions.Configuration;
using OnlineStore.Core;
using OnlineStore.Core.Dtos.Payment;
using OnlineStore.Core.Entities;
using OnlineStore.Core.Entities.Order;
using OnlineStore.Core.IServices.Orders;
using OnlineStore.Core.IServices.Payment;
using Stripe;
using Stripe.Treasury;
using System.Security.Claims;

namespace OnlineStore.Service.Services.Payment
{
	public class PaymentService : IPaymentService
	{
		private readonly IOrderService _orderService;
		private readonly IConfiguration _configuration;
		private readonly IUnitOfWork _unitOfWork;

		public PaymentService(IOrderService orderService,IConfiguration configuration,IUnitOfWork unitOfWork)
		{
			_orderService = orderService;
			_configuration = configuration;
			_unitOfWork = unitOfWork;
		}
		public async Task<PaymentDto> CreateOrUpdatePaymentIntentId(ClaimsPrincipal user,int orderId)
		{
			StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];

			var order = await _orderService.GetOrderByIdForUserAsync(user, orderId);

			if (order is null) return null;

			long priceFull = (long)order.GetTotal();
			long priceUSD = priceFull / long.Parse(_configuration["CurrencyPrice"]);

			long price = priceUSD * 100;

			var service = new PaymentIntentService();

			PaymentIntent payment;

			if (string.IsNullOrEmpty(order.PaymentIntentId)) 
			{
				var option = new PaymentIntentCreateOptions()
				{
					Amount = price,
					PaymentMethodTypes = new List<string>() { "card"} ,
					Currency = "usd",
					Metadata = new Dictionary<string, string>
					{
						{ "orderId", order.Id.ToString() }
					}
				};

				payment = await service.CreateAsync(option);

				order.PaymentIntentId = payment.Id;
				order.ClientSecret = payment.ClientSecret;
			}
			else 
			{
				var option = new PaymentIntentUpdateOptions()
				{
					Amount = price,
				};

				payment = await service.UpdateAsync(order.PaymentIntentId,option);

				order.PaymentIntentId = payment.Id;
				order.ClientSecret = payment.ClientSecret;
			}

			_unitOfWork.Repository<Order, int>().Update(order);
			await _unitOfWork.CompleteAsync();

			return new PaymentDto() { ClientSecret = order.ClientSecret , PaymentIntentId = order.PaymentIntentId ,OrderId = order.Id};
		}

		public async Task<Order> UpdateOrderStatus(string paymentIntentId, bool flag)
		{
			var order = await _orderService.GetOrderByPaymentIntentIdForUserAsync(paymentIntentId);

			if (flag) 
			{
				order.Status = OrderStatus.PaymentReceived;
			}
			else 
			{
				order.Status = OrderStatus.PaymentFaild;
			}
			_unitOfWork.Repository<Order, int>().Update(order);
			await _unitOfWork.CompleteAsync();

			return order;
		}
	}
}

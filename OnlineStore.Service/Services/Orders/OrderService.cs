using OnlineStore.Core;
using OnlineStore.Core.Entities;
using OnlineStore.Core.Entities.Order;
using OnlineStore.Core.IServices.Auth;
using OnlineStore.Core.IServices.Basket;
using OnlineStore.Core.IServices.Orders;
using OnlineStore.Core.Specifications.Orders;
using System.Security.Claims;

namespace OnlineStore.Service.Services.Orders
{
	public class OrderService : IOrderService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IBasketService _basketService;
		private readonly IUserService _userService;

		public OrderService(IUnitOfWork unitOfWork,IBasketService basketService, IUserService userService)
		{
			_unitOfWork = unitOfWork;
			_basketService = basketService;
			_userService = userService;
		}
		public async Task<Order> CreateOrderasync(ClaimsPrincipal user , string basketId, int deliveryMethodId, Address shippingAddress)
		{

			var buyer = await _userService.CurrentUser(user);

			if (buyer is null) return null;

			var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod, int>().GetAsync(deliveryMethodId);

			var basket = await _basketService.GetByIdAsync(basketId);

			if(basket is  null) return null;

			var items = new List<OrderItem>();

			if(basket.Items.Count > 0) 
			{
				foreach (var item in basket.Items)
				{
					var product = await _unitOfWork.Repository<Product, int>().GetAsync(item.Id); // Product from DB
					var productItemOrder = new ProductItemOrder(product.Id,product.Name,product.PictureUrl);
					var orderItem = new OrderItem(productItemOrder,product.Price,item.Quantity);

					items.Add(orderItem);
				}
			}

			decimal subTotal = items.Sum(x => x.Price * x.Quantity);

			var order = new Order(buyer.Email, shippingAddress, deliveryMethod, items, subTotal,"","");

			await _unitOfWork.Repository<Order, int>().AddAsync(order);

			var result = await _unitOfWork.CompleteAsync();

			if (result <= 0) return null;

			return order;
		}

		public async Task<Order?> GetOrderByIdForUserAsync(ClaimsPrincipal user, int orderId)
		{
			var buyer = await _userService.CurrentUser(user);

			if (buyer is null) return null;

			var spec = new OrderSpecifications(buyer.Email, orderId);

			var order = await _unitOfWork.Repository<Order, int>().GetAsync(spec);

			return order;
		}

		public async Task<Order?> GetOrderByPaymentIntentIdForUserAsync(string paymentIntentId)
		{

			var spec = new OrderByPaymentIntentIdSpecifications(paymentIntentId);

			var order = await _unitOfWork.Repository<Order, int>().GetAsync(spec);

			return order;
		}

		public async Task<IEnumerable<Order?>> GetOrdersForUserAsync(ClaimsPrincipal user)
		{
			var buyer = await _userService.CurrentUser(user);

			if (buyer is null) return null;

			var spec = new OrderSpecifications(buyer.Email);

			var orders = await _unitOfWork.Repository<Order, int>().GetAllAsync(spec);

			return orders;
		}
	}
}

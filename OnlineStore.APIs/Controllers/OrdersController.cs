namespace OnlineStore.APIs.Controllers
{
	public class OrdersController : OnlineStoreController
	{
		private readonly IOrderService _orderService;

		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}
		[HttpPost("CreateOrder")]
		public async Task<IActionResult> CreateOrder(CreateOrderDto dto) 
		{
			var order = await _orderService.CreateOrderasync(User,dto.BasketId,dto.DeliveryMethodId,dto.ShippingAddress);

			if (order is null) 
				return BadRequest(new ApiResponseError(StatusCodes.Status400BadRequest,$"an error while create order"));
			
			return Ok(order);
		}
		[HttpGet("GetOrderByIdForUserAsync")]
		public async Task<IActionResult> GetOrderByIdForUserAsync(int orderId)
		{
			var order = await _orderService.GetOrderByIdForUserAsync(User,orderId);

			if (order is null)
				return BadRequest(new ApiResponseError(StatusCodes.Status400BadRequest, $"an error while get order"));

			return Ok(order);
		}
		[HttpGet("GetOrdersForUserAsync")]
		public async Task<IActionResult> GetOrdersForUserAsync()
		{
			var order = await _orderService.GetOrdersForUserAsync(User);

			if (order is null)
				return BadRequest(new ApiResponseError(StatusCodes.Status400BadRequest, $"an error while get orders"));

			return Ok(order);
		}
	}
}

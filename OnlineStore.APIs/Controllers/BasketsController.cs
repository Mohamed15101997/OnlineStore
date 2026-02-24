namespace OnlineStore.APIs.Controllers
{
	public class BasketsController : OnlineStoreController
	{
		private readonly IBasketService _basketService;

		public BasketsController(IBasketService basketService)
		{
			_basketService = basketService;
		}
		[HttpGet]
		public async Task<ActionResult<CustomerBasket>> GetById(string? id) 
		{
			if (id is null) 
				return BadRequest(new ApiResponseError(StatusCodes.Status400BadRequest));

			var basket = await _basketService.GetByIdAsync(id);
			if (basket is null)
				new CustomerBasket { Id = id };

			return Ok(basket);
		}
		[HttpPost]
		public async Task<ActionResult<CustomerBasket>> UpdateOrCreate(CustomerBasketDto dto) 
		{
			var basket = await _basketService.CreateOrUpdateAsync(dto);

			if (basket is null)
				return BadRequest(new ApiResponseError(StatusCodes.Status400BadRequest));
			return Ok(basket);
		}
		[HttpDelete]
		public async Task Delete(string id) 
		{
			await _basketService.DeleteAsync(id);
		}
	}
}

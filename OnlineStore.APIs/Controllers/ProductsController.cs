namespace OnlineStore.APIs.Controllers
{
	public class ProductsController : OnlineStoreController
	{
		private readonly IProductsService _productsService;

		public ProductsController(IProductsService productsService)
		{
			_productsService = productsService;
		}
		[ProducesResponseType(typeof(PaginationResponse<ProductDto>), StatusCodes.Status200OK)]
		[HttpGet("GetAllProducts")]
		[Cashed(100)]
		[Authorize]
		public async Task<ActionResult<PaginationResponse<ProductDto>>> GetAllProducts([FromQuery] ProductSpecParams param) 
		{
			return Ok(await _productsService.GetAllProductsAsync(param));
		}
		[ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponseError), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(typeof(ApiResponseError), StatusCodes.Status404NotFound)]
		[HttpGet("GetProductById/{id}")]
		[Authorize]
		public async Task<IActionResult> GetProductById(int? id) 
		{
			if (id is null)
				return BadRequest(new ApiResponseError(StatusCodes.Status400BadRequest , $"id must be required"));
			var result = await _productsService.GetProductByIdAsync(id.Value);
			if (result is null)
				return NotFound(new ApiResponseError(StatusCodes.Status404NotFound , $"Product With Id {id} Not Found"));
			return Ok();
		}
	}
}

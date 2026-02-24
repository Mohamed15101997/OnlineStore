namespace OnlineStore.APIs.Controllers
{
	public class ProductTypesController : OnlineStoreController
	{
		private readonly IProductTypesService _productTypesService;

		public ProductTypesController(IProductTypesService productTypesService)
		{
			_productTypesService = productTypesService;
		}
		[ProducesResponseType(typeof(IEnumerable<ProductTypeDto>), StatusCodes.Status200OK)]
		[HttpGet("GetAllProductTypes")]
		public async Task<ActionResult<IEnumerable<ProductTypeDto>>> GetAllProductTypes() 
		{
			return Ok(await _productTypesService.GetAllProductTypesAsync());
		}
	}
}

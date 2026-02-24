namespace OnlineStore.APIs.Controllers
{
	public class BrandsController : OnlineStoreController
	{
		private readonly IBrandsService _brandsService;

		public BrandsController(IBrandsService brandsService)
		{
			_brandsService = brandsService;
		}
		[ProducesResponseType(typeof(IEnumerable<BrandDto>),StatusCodes.Status200OK)]
		[HttpGet("GetAllBrands")]
		public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands()
		{
			return Ok(await _brandsService.GetAllBrands());
		}
	}
}

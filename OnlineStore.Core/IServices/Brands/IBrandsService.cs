using OnlineStore.Core.Dtos.Brands;

namespace OnlineStore.Core.IServices.Brands
{
	public interface IBrandsService
	{
		Task<IEnumerable<BrandDto>> GetAllBrands();
	}
}

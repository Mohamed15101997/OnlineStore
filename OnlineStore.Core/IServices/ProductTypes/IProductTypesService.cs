using OnlineStore.Core.Dtos.ProductTypes;

namespace OnlineStore.Core.IServices.ProductTypes
{
	public interface IProductTypesService
	{
		Task<IEnumerable<ProductTypeDto>> GetAllProductTypesAsync();
	}
}

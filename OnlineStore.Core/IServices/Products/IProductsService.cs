using OnlineStore.Core.Dtos.Products;
using OnlineStore.Core.Helper;
using OnlineStore.Core.Specifications.ProductSpecification;

namespace OnlineStore.Core.IServices.Products
{
	public interface IProductsService
	{
		Task<PaginationResponse<ProductDto>> GetAllProductsAsync(ProductSpecParams param);
		Task<ProductDto> GetProductByIdAsync(int id);
	}
}

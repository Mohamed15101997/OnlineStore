using AutoMapper;
using OnlineStore.Core;
using OnlineStore.Core.Dtos.Products;
using OnlineStore.Core.Entities;
using OnlineStore.Core.Helper;
using OnlineStore.Core.IServices.Products;
using OnlineStore.Core.Specifications.ProductSpecification;

namespace OnlineStore.Service.Services.Products
{
	public class ProductsService : IProductsService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ProductsService(IUnitOfWork unitOfWork,IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<PaginationResponse<ProductDto>> GetAllProductsAsync(ProductSpecParams param)
		{
			var spec = new ProductSpecifications(param);

			var productData = await _unitOfWork.Repository<Product, int>().GetAllAsync(spec);

			var specCount = new ProductCountSpecifications(param);

			var ProductsCount = await _unitOfWork.Repository<Product, int>().GetCountAsync(specCount);

			var mappedResult =  _mapper.Map<IEnumerable<ProductDto>>(productData);

			return new PaginationResponse<ProductDto>(param.PageNumber, param.PageSize, ProductsCount, mappedResult);
		}
		public async Task<ProductDto> GetProductByIdAsync(int id)
		{
			var spec = new ProductSpecifications(id);
			// Get Date From Db 
			var product = await _unitOfWork.Repository<Product,int>().GetAsync(spec);
			// Map Data
			var mapped = _mapper.Map<ProductDto>(product);

			return mapped;
		}
	}
}

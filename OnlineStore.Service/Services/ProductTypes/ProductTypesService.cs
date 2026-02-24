using AutoMapper;
using OnlineStore.Core;
using OnlineStore.Core.Dtos.ProductTypes;
using OnlineStore.Core.Entities;
using OnlineStore.Core.IServices.ProductTypes;

namespace OnlineStore.Service.Services.ProductTypes
{
	public class ProductTypesService : IProductTypesService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ProductTypesService(IUnitOfWork unitOfWork , IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<IEnumerable<ProductTypeDto>> GetAllProductTypesAsync()
			=> _mapper.Map<IEnumerable<ProductTypeDto>>(await _unitOfWork.Repository<ProductType,int>().GetAllAsync());
	}
}

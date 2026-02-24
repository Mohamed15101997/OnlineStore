using AutoMapper;
using OnlineStore.Core;
using OnlineStore.Core.Dtos.Brands;
using OnlineStore.Core.Entities;
using OnlineStore.Core.IServices.Brands;

namespace OnlineStore.Service.Services.Brands
{
	public class BrandsService : IBrandsService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public BrandsService(IUnitOfWork unitOfWork , IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<IEnumerable<BrandDto>> GetAllBrands()
			=> _mapper.Map<IEnumerable<BrandDto>>(await _unitOfWork.Repository<Brand,int>().GetAllAsync());
	}
}

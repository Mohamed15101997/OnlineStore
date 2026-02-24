using AutoMapper;
using OnlineStore.Core.Dtos.Brands;
using OnlineStore.Core.Entities;

namespace OnlineStore.Core.Mapping.Brands
{
	public class BrandProfile : Profile
	{
		public BrandProfile()
		{
			MapEntity();
		}
		public void MapEntity() 
		{
			CreateMap<Brand, BrandDto>();
		}
	}
}

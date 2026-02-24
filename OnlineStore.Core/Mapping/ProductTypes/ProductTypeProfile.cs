using AutoMapper;
using OnlineStore.Core.Dtos.ProductTypes;
using OnlineStore.Core.Entities;

namespace OnlineStore.Core.Mapping.ProductTypes
{
	public class ProductTypeProfile : Profile
	{
		public ProductTypeProfile()
		{
			MapEntity();
		}
		public void MapEntity() 
		{
			CreateMap<ProductType, ProductTypeDto>();
		}
	}
}

using AutoMapper;
using OnlineStore.Core.Dtos.Baskets;
using OnlineStore.Core.Entities;

namespace OnlineStore.Core.Mapping.Basket
{
	public class BasketProfile : Profile
	{
		public BasketProfile()
		{
			MapEntity();
		}
		public void MapEntity() 
		{
			CreateMap<CustomerBasketDto,CustomerBasket>().ReverseMap();
			CreateMap<BasketItemDto,BasketItem>().ReverseMap();
		}
	}
}

using AutoMapper;
using OnlineStore.Core.Dtos.Baskets;
using OnlineStore.Core.Entities;
using OnlineStore.Core.IRepositories;
using OnlineStore.Core.IServices.Basket;

namespace OnlineStore.Service.Services.Basket
{
	public class BasketService : IBasketService
	{
		private readonly IBasketRepository _basketRepository;
		private readonly IMapper _mapper;

		public BasketService(IBasketRepository basketRepository,IMapper mapper)
		{
			_basketRepository = basketRepository;
			_mapper = mapper;
		}
		public async Task<CustomerBasketDto?> GetByIdAsync(string id)
		{
			var basket = await _basketRepository.GetByIdAsync(id);

			if (basket is null)
				return _mapper.Map<CustomerBasketDto>(new CustomerBasket { Id = id});

			return _mapper.Map<CustomerBasketDto>(basket);
		}
		public async Task<CustomerBasketDto?> CreateOrUpdateAsync(CustomerBasketDto dto)
		{
			var basket = await _basketRepository.UpdateAsync(_mapper.Map<CustomerBasket>(dto));

			if (basket is not null)
				return _mapper.Map<CustomerBasketDto>(basket);

			return null;
		}

		public Task<bool> DeleteAsync(string id)
		{
			return _basketRepository.DeleteAsync(id);
		}

		
	}
}

using OnlineStore.Core.Dtos.Baskets;
using OnlineStore.Core.Entities;

namespace OnlineStore.Core.IServices.Basket
{
	public interface IBasketService
	{
		Task<CustomerBasketDto?> GetByIdAsync(string id);
		Task<CustomerBasketDto?> CreateOrUpdateAsync(CustomerBasketDto dto);
		Task<bool> DeleteAsync(string id);
	}
}

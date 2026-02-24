using OnlineStore.Core.Entities;

namespace OnlineStore.Core.IRepositories
{
	public interface IBasketRepository
	{
		Task<CustomerBasket?> GetByIdAsync(string id);
		Task<CustomerBasket?> UpdateAsync(CustomerBasket model);
		Task<bool> DeleteAsync(string id);
	}
}

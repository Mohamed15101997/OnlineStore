using OnlineStore.Core.Entities;
using OnlineStore.Core.IRepositories;
using StackExchange.Redis;
using System.Text.Json;

namespace OnlineStore.Repository.Repositories
{
	public class BasketRepository : IBasketRepository
	{
		private readonly IDatabase _database;
		public BasketRepository(IConnectionMultiplexer redis)
		{
			_database = redis.GetDatabase();
		}
		public async Task<bool> DeleteAsync(string id) => await _database.KeyDeleteAsync(id);
		public async Task<CustomerBasket?> GetByIdAsync(string id)
		{
			var basket = await _database.StringGetAsync(id);
			return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(basket);
		}
		public async Task<CustomerBasket?> UpdateAsync(CustomerBasket model)
		{
			var isUpdateOrSaved = await _database.StringSetAsync(model.Id,JsonSerializer.Serialize(model),TimeSpan.FromDays(30));
			if (!isUpdateOrSaved)
				return null;
			return await GetByIdAsync(model.Id);
		}
	}
}

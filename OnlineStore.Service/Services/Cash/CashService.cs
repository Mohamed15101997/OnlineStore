using OnlineStore.Core.IServices.Cashing;
using StackExchange.Redis;
using System.Text.Json;

namespace OnlineStore.Service.Services.Cash
{
	public class CashService : ICashService
	{
		private readonly IDatabase _database;
		public CashService(IConnectionMultiplexer redis)
		{
			_database = redis.GetDatabase();
		}
		public async Task<string> GetCashKeyAsync(string key)
		{
			var cashResponse = await _database.StringGetAsync(key);

			if (cashResponse.IsNullOrEmpty)
				return null;

			return cashResponse.ToString();
		}

		public async Task SetCashKeyAsync(string key, object response, TimeSpan expireTime)
		{
			if (response is null)
				return;

			var options = new JsonSerializerOptions()
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			};
			await _database.StringSetAsync(key , JsonSerializer.Serialize(response,options),expireTime);

		}
	}
}

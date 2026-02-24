namespace OnlineStore.Core.IServices.Cashing
{
	public interface ICashService
	{
		Task SetCashKeyAsync(string key , object response , TimeSpan expireTime);
		Task<string> GetCashKeyAsync(string key);
	}
}

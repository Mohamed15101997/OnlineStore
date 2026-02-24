using OnlineStore.Core.Entities;
using OnlineStore.Core.IRepositories;

namespace OnlineStore.Core
{
	public interface IUnitOfWork
	{
		Task<int> CompleteAsync();
		IGenericRepository<TEntity ,TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
	}
}

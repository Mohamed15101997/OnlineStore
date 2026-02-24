using OnlineStore.Core.Entities;
using OnlineStore.Core.Specifications;

namespace OnlineStore.Core.IRepositories
{
	public interface IGenericRepository<TEntity,TKey> where TEntity : BaseEntity<TKey>
	{
		Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity,TKey> spec);
		Task<IEnumerable<TEntity>> GetAllAsync();
		Task<TEntity> GetAsync(TKey id);
		Task<TEntity> GetAsync(ISpecifications<TEntity, TKey> spec);
		Task AddAsync(TEntity entity);
		Task<int> GetCountAsync(ISpecifications<TEntity, TKey> spec);
		void Update(TEntity entity);
		void Delete(TEntity entity);
	}
}

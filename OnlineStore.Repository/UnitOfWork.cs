using OnlineStore.Core;
using OnlineStore.Core.Entities;
using OnlineStore.Core.IRepositories;
using OnlineStore.Repository.Data.Contexts;
using OnlineStore.Repository.Repositories;
using System.Collections;

namespace OnlineStore.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly StoreDbContext _context;
		private Hashtable _repositories;

		public UnitOfWork(StoreDbContext context)
		{
			_context = context;
			_repositories = new Hashtable();
		}
		public async Task<int> CompleteAsync()
		{
			return await _context.SaveChangesAsync();
		}
		public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
		{
			var typeName = typeof(TEntity).Name;
			if (!_repositories.ContainsKey(typeName)) 
			{
				var repository = new GenericRepository<TEntity, TKey>(_context);
				_repositories.Add(typeName, repository);
			}
			return _repositories[typeName] as IGenericRepository<TEntity,TKey>;
		}
	}
}

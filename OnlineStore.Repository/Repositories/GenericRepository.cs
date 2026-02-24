using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities;
using OnlineStore.Core.IRepositories;
using OnlineStore.Core.Specifications;
using OnlineStore.Repository.Data.Contexts;

namespace OnlineStore.Repository.Repositories
{
	public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
	{
		private readonly StoreDbContext _context;

		public GenericRepository(StoreDbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			if(typeof(TEntity) == typeof(Product)) 
			{
				return (IEnumerable<TEntity>) await  _context.Products.Include(x => x.Brand).Include(x => x.Type).ToListAsync();
			}
			return await _context.Set<TEntity>().ToListAsync();
		}
		public async Task<TEntity> GetAsync(TKey id)
		{
			if (typeof(TEntity) == typeof(Product))
			{
				return  await (_context.Products.Include(x => x.Brand).Include(x => x.Type).FirstOrDefaultAsync(x => x.Id == id as int?)) as TEntity;
			}
			return await _context.Set<TEntity>().FindAsync(id);
		}
		public async Task AddAsync(TEntity entity)
		{
			 await _context.AddAsync(entity);
		}
		public void Update(TEntity entity)
		{
			_context.Update(entity);
		}
		public void Delete(TEntity entity)
		{
			_context.Remove(entity);
		}
		public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, TKey> spec)
		{
			return await ApplySpecifications(spec).ToListAsync();
		}
		public async Task<TEntity> GetAsync(ISpecifications<TEntity, TKey> spec)
		{
			return await ApplySpecifications(spec).FirstOrDefaultAsync();
		}
		public IQueryable<TEntity> ApplySpecifications(ISpecifications<TEntity, TKey> spec) 	
			=> SpecificationsEvaluator<TEntity, TKey>.GetQuery(_context.Set<TEntity>(), spec);

		public async Task<int> GetCountAsync(ISpecifications<TEntity, TKey> spec)
		{
			return await ApplySpecifications(spec).CountAsync();
		}
	}
}

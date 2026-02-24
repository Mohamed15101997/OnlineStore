using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities;
using OnlineStore.Core.Specifications;

namespace OnlineStore.Repository
{
	public static class SpecificationsEvaluator<TEntity,TKey> where TEntity : BaseEntity<TKey>
	{
		public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery , ISpecifications<TEntity,TKey> spec) 
		{
			var query = inputQuery;
			// [1] Where
			if(spec.Criteria is not null) 
			{
				query = query.Where(spec.Criteria);
			}
			// [2] Sort
			if(spec.OrderBy is not null) 
			{
				query = query.OrderBy(spec.OrderBy);
			}
			if (spec.OrderByDescending is not null)
			{
				query = query.OrderByDescending(spec.OrderByDescending);
			}
			// [3] Pagination
			if (spec.IsPaginationEnabled) 
			{
				query = query.Skip(spec.Skip).Take(spec.Take);
			}
			// [4] Includes
			// _context.Product -> [1] [currentQuery = _context.Product]
			// _context.Product.Include(p => p.Brand) -> [2] [currentQuery = _context.Product] [includeExpression = p => p.Brand]
			// _context.Product.Include(p => p.Brand).Include(p => p.ProductType) -> [3] [currentQuery = _context.Product.Include(p => p.Brand)] [includeExpression = p => p.ProductType]
			query = spec.Includes.Aggregate(query,(currentQuery,includeExpression) => currentQuery.Include(includeExpression));
			return query;
		}
	}
}

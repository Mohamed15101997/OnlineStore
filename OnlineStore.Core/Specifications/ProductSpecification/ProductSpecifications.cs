using OnlineStore.Core.Entities;

namespace OnlineStore.Core.Specifications.ProductSpecification
{
	public class ProductSpecifications : BaseSpecifications<Product,int>
	{
		public ProductSpecifications(int id) :base(p => p.Id == id)
		{
			ApplyIncludes();
		}
		public ProductSpecifications(ProductSpecParams param) 
			: base(p => 
			(string.IsNullOrEmpty(param.Search) || p.Name.ToLower().Contains(param.Search)) 
				&&
			(!param.BrandId.HasValue || param.BrandId == p.BrandId) 
				&& 
			(!param.TypeId.HasValue || param.TypeId == p.ProductTypeId))
		{
			if (!string.IsNullOrEmpty(param.Sort)) 
			{
				switch (param.Sort)
				{
					case "priceAsc":
						AddOrderBy(p => p.Price);
						break;
					case  "priceDesc":
						AddOrderByDescending(p => p.Price);
						break;
					default:
						AddOrderBy(p => p.Name);
						break;
				}
			}
			else 
			{
				AddOrderBy(p => p.Name);
			}
			ApplyIncludes();
			ApplyPagination(param.PageSize * (param.PageNumber - 1), param.PageSize);

		}
		public void ApplyIncludes() 
		{
			Includes.Add(p => p.Brand);
			Includes.Add(p => p.Type);
		}
	}
}

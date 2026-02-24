using OnlineStore.Core.Entities;

namespace OnlineStore.Core.Specifications.ProductSpecification
{
	public class ProductCountSpecifications : BaseSpecifications<Product, int>
	{
		public ProductCountSpecifications(ProductSpecParams param) 
			: base(p =>
			(string.IsNullOrEmpty(param.Search) || p.Name.ToLower().Contains(param.Search))
				&&
			(!param.BrandId.HasValue || param.BrandId == p.BrandId) 
				&& 
			(!param.TypeId.HasValue || param.TypeId == p.ProductTypeId))
		{
		}
	}
}

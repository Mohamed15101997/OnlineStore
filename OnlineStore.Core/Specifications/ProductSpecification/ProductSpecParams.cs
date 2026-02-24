namespace OnlineStore.Core.Specifications.ProductSpecification
{
	public class ProductSpecParams
	{
		private string? search;

		public string? Search
		{
			get { return search; }
			set { search = value?.ToLower(); }
		}

		public string? Sort { get; set; }
		public int? BrandId { get; set; }
		public int? TypeId { get; set; }
		public int PageNumber { get; set; } = 1;
		public int PageSize{ get; set; } = 5;
	}
}

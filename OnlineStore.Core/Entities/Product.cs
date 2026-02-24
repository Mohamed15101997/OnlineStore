namespace OnlineStore.Core.Entities
{
	public class Product : BaseEntity<int>
	{
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string PictureUrl { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public int? BrandId { get; set; }
		public Brand Brand { get; set; }
		public int? ProductTypeId { get; set; }
		public ProductType Type { get; set; }

	}
}

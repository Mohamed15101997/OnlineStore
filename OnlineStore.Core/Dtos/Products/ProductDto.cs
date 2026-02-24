using OnlineStore.Core.Entities;

namespace OnlineStore.Core.Dtos.Products
{
	public class ProductDto
	{
		public int id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string PictureUrl { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public string BrandName { get; set; } = string.Empty;
		public int BrandId { get; set; } 
		public string ProductTypeName { get; set; } = string.Empty;
		public int ProductTypeId { get; set; } 
		public DateTime CreatedAt { get; set; }
	}
}

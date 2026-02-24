using OnlineStore.Core.Entities;
using OnlineStore.Core.Entities.Order;
using OnlineStore.Repository.Data.Contexts;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace OnlineStore.Repository.Data
{
	public static class StoreDbContextSeed
	{
		public async static Task SeedAsync(StoreDbContext _context) 
		{
			if(_context.Brands.Count() == 0) 
			{
				// Brands 
				// [1] Read All Data From json
				var brandsData = File.ReadAllText(@"..\OnlineStore.Repository\Data\DataSeed\brands.json");
				// [2] Convert To Object 
				var brands = JsonSerializer.Deserialize<List<Brand>>(brandsData);
				// [3] Save to Database
				if(brands is not null && brands.Count > 0) 
				{
					await _context.Brands.AddRangeAsync(brands);
				}
			}
			if (_context.ProductTypes.Count() == 0)
			{
				// ProductTypes 
				// [1] Read All Data From json
				var TypesData = File.ReadAllText(@"..\OnlineStore.Repository\Data\DataSeed\types.json");
				// [2] Convert To Object 
				var ProductTypes = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
				// [3] Save to Database
				if (ProductTypes is not null && ProductTypes.Count > 0)
				{
					await _context.ProductTypes.AddRangeAsync(ProductTypes);
				}
			}
			if (_context.Products.Count() == 0)
			{
				// Products 
				// [1] Read All Data From json
				var ProductsData = File.ReadAllText(@"..\OnlineStore.Repository\Data\DataSeed\products.json");
				// [2] Convert To Object 
				var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
				// [3] Save to Database
				if (Products is not null && Products.Count > 0)
				{
					await _context.Products.AddRangeAsync(Products);
				}
			}
			if (_context.DeliveryMethods.Count() == 0)
			{
				// DeliveryMethods 
				// [1] Read All Data From json
				var DeliveryMethodData = File.ReadAllText(@"..\OnlineStore.Repository\Data\DataSeed\delivery.json");
				// [2] Convert To Object 
				var DeliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(DeliveryMethodData);
				// [3] Save to Database
				if (DeliveryMethods is not null && DeliveryMethods.Count > 0)
				{
					await _context.DeliveryMethods.AddRangeAsync(DeliveryMethods);
				}
			}
			await _context.SaveChangesAsync();

		}
	}
}

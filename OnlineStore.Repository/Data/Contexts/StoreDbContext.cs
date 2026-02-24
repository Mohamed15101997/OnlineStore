using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities;
using OnlineStore.Core.Entities.Order;
using System.Reflection;

namespace OnlineStore.Repository.Data.Contexts
{
	public class StoreDbContext : DbContext
	{
		public StoreDbContext(DbContextOptions<StoreDbContext> option) : base(option)
		{		
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
	}
}

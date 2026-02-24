using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.Order;

namespace OnlineStore.Repository.Data.Configurations
{
	public class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder)
		{
			builder.OwnsOne(p => p.Product, p => p.WithOwner());
			builder.Property(p => p.Price)
				.HasColumnType("decimal(18,2)");
		}
	}
}

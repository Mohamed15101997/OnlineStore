using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.Order;

namespace OnlineStore.Repository.Data.Configurations
{
	public class OrderConfigurations : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.Property(p => p.SubTotal)
				.HasColumnType("decimal(18,2)");
			builder.Property(p => p.Status)
				.HasConversion(s => s.ToString(),s => (OrderStatus)Enum.Parse(typeof(OrderStatus), s));
			builder.OwnsOne(p => p.ShippingAddress , sa => sa.WithOwner());
			builder.HasOne(p => p.DeliveryMethod)
				.WithMany()
				.HasForeignKey(p => p.DeliveryMethodId);

		}
	}
}

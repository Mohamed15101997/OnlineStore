using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities.Order;

namespace OnlineStore.Repository.Data.Configurations
{
	public class DeliveryMethodConfigurations : IEntityTypeConfiguration<DeliveryMethod>
	{
		public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
		{
			builder.Property(p => p.Cost)
				.HasColumnType("decimal(18,2)");
		}
	}
}

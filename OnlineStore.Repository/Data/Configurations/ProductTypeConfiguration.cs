using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities;

namespace OnlineStore.Repository.Data.Configurations
{
	public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
	{
		public void Configure(EntityTypeBuilder<ProductType> builder)
		{
			builder.Property(p => p.Name).IsRequired();
		}
	}
}

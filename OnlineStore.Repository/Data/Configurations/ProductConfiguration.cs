using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities;

namespace OnlineStore.Repository.Data.Configurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
			builder.Property(p => p.PictureUrl).IsRequired();
			builder.Property(p => p.Description).IsRequired(true);
			builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
			builder.Property(p => p.BrandId).IsRequired(false);
			builder.Property(p => p.ProductTypeId).IsRequired(false);

			builder.HasOne(p => p.Brand)
				.WithMany()
				.HasForeignKey(p => p.BrandId)
				.OnDelete(DeleteBehavior.SetNull);

			builder.HasOne(p => p.Type)
				.WithMany()
				.HasForeignKey(p => p.ProductTypeId)
				.OnDelete(DeleteBehavior.SetNull);

		}
	}
}

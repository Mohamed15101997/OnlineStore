using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Entities;

namespace OnlineStore.Repository.Data.Configurations
{
	public class BrandConfiguration : IEntityTypeConfiguration<Brand>
	{
		public void Configure(EntityTypeBuilder<Brand> builder)
		{
			builder.Property(p => p.Name).IsRequired();
		}
	}
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalog.Domain.Models;

namespace NerdStore.Catalog.Data.Mapping
{
	public class ProductMapping : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(p => p.Id);

			builder.Property(p => p.Name)
				.IsRequired()
				.HasColumnType("varchar(250)");

			builder.Property(p => p.Description)
				.IsRequired()
				.HasColumnType("varchar(500)");

			builder.Property(p => p.Image)
				.IsRequired()
				.HasColumnType("varchar(250)");

			builder.OwnsOne(p => p.Dimensions, cm =>
			{
				cm.Property(c => c.Height)
				.HasColumnName("Height")
				.HasColumnType("int");

				cm.Property(c => c.Width)
				.HasColumnName("Width")
				.HasColumnType("int");

				cm.Property(c => c.Depth)
				.HasColumnName("Depth")
				.HasColumnType("int");
			});

			builder.ToTable("Products");
		}
	}
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalog.Domain.Models;

namespace NerdStore.Catalog.Data.Mapping
{
	public class CategoryMapping : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Name)
				.IsRequired()
				.HasColumnType("varchar(250)");

			builder.Property(c => c.Code)
				.IsRequired()
				.HasColumnType("varchar(500)");

			//1:N
			builder.HasMany(c => c.Products)
				.WithOne(p => p.Category)
				.HasForeignKey(p => p.CategoryId);

			builder.ToTable("Categories");
		}
	}
}

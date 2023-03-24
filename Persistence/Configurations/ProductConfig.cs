using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ProductConfig : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.Property(c => c.Name).HasMaxLength(50);
		builder.Property(c => c.Description).HasMaxLength(500);

		builder.HasData(new Product
		{
			Id = 1,
			Barcode = "5412",
			Description = "Description about",
			Name = "Tractor",
			Rate = 45,
		});
	}
}

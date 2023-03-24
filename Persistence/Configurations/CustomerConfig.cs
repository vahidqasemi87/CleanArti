using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class CustomerConfig : IEntityTypeConfiguration<Customer>
{
	public void Configure(EntityTypeBuilder<Customer> builder)
	{
		builder.Property(c => c.Name).HasMaxLength(50);
		builder.Property(c => c.Address).HasMaxLength(256);
		builder.Property(c => c.Family).HasMaxLength(150);
		builder.Property(c => c.Mobile).HasMaxLength(20);
		builder.Property(c => c.Password).HasMaxLength(150);
		builder.Property(c => c.Username).HasMaxLength(150);
	}
}

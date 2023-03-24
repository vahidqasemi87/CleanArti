using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Threading.Tasks;

namespace Persistence.Context;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext, IApplicationDbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{

	}


	public DbSet<Product> Products { get; set; }
	public DbSet<Customer> Customers { get; set; }
	public DbSet<Order> Orders { get; set; }


	public async Task<int> SaveChangesAsync()
	{
		return await base.SaveChangesAsync();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
	}
}
public class ApplicationDbContextFactory :
	IDesignTimeDbContextFactory<ApplicationDbContext>
{
	public ApplicationDbContext CreateDbContext(string[] args)
	{
		var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
		builder.UseSqlServer("server=.;database=CleanDb;uid=sa;pwd=Ss1234!@#$;TrustServerCertificate=true;");
		return new ApplicationDbContext(builder.Options);
	}
}

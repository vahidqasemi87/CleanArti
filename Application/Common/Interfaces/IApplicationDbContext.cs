using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IApplicationDbContext
{
	public DbSet<Product> Products { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<Customer> Customers { get; set; }

	System.Threading.Tasks.Task<int> SaveChangesAsync();
}

//public class ApplicationDbContext : DbContext, IApplicationDbContext
//{
//	public DbSet<Product> Products { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
//	public DbSet<Order> Orders { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
//	public DbSet<Customer> Customers { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

//	public Task<int> SaveChangesAsync()
//	{
//		throw new System.NotImplementedException();
//	}
//}
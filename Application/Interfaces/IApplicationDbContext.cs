using Domain.Entities;

namespace Application.Interfaces;

public interface IApplicationDbContext
{
	public Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Order> Orders { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Customer> Customers { get; set; }

    System.Threading.Tasks.Task<int> SaveChangesAsync();
}
using Domain.Entities;

namespace Application.Interfaces;

public interface IApplicationDbContext
{
	public Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; set; }
	System.Threading.Tasks.Task<int> SaveChangesAsync();
}
using IdentityDemo.Contracts;
using IdentityDemo.Infrastructurs.Context;
using Microsoft.EntityFrameworkCore;

namespace IdentityDemo.Infrastructurs.Data;

public class Repository<T> : IRepository<T> where T : class
{
	private readonly IdentityServerDbContext _context;
	private readonly DbSet<T> Entity;


	public Repository(IdentityServerDbContext context)
	{
		_context = context;
		Entity = _context.Set<T>();
	}


	public void Add(T entity)
	{
		Entity.Add(entity);
	}

	public void Delete(T entity)
	{
		Entity.Remove(entity);
	}
}

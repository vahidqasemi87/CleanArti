using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces;

public class Repository<T> : IRepository<T> where T : class
{
	private readonly IApplicationDbContext _context;
	private readonly DbSet<T> Entity;

    public Repository(IApplicationDbContext context)
    {
		_context = context;
		
    }
    public Task AddAsync(T entity)
	{
		
		throw new NotImplementedException();
	}

	public void Delete(T entity)
	{
		throw new NotImplementedException();
	}
}

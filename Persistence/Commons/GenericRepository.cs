using Application.Common.Interfaces.Learning02;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Commons
{
	public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		public readonly ApplicationDbContext _context;
		public DbSet<T> DbSet { get; set; }
		public GenericRepository(ApplicationDbContext context)
		{
			_context = context;
			DbSet = _context.Set<T>();
		}
		public async Task AddAsync(T entity)
		{
			await DbSet.AddAsync(entity);
		}

		public async Task Delete(int id)
		{
			var result = DbSet.Find(id);
			_context.Set<T>().Remove(result);
		}

		public async Task<T> GetAsync(int id)
		{
			var result = await DbSet.FindAsync(id);
			return result;
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			var result = await DbSet.ToListAsync();
			return result;
		}

		public async Task Update(int id, T entity)
		{
			var result = await DbSet.FindAsync(id);
			DbSet.Update(result);
		}


	}
}
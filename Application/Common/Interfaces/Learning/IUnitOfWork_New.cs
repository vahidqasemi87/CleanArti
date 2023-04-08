//using Application.Interfaces;
//using Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Internal;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Threading.Tasks;

//namespace Application.Common.Interfaces.Learning;


//public class ContextDemo : DbContext//, IApplicationDbContext
//{
//	public virtual DbSet<Product> Products { get; set; }
//	public virtual DbSet<Order> Orders { get; set; }
//	public virtual DbSet<Customer> Customers { get; set; }

//	public async Task<int> SaveChangesAsync()
//	{
//		return await base.SaveChangesAsync();
//	}
//}

////Step01//


//public interface IRepository_New<TEntity> where TEntity : class
//{
//	Task<TEntity> GetByIdAsync(int id);
//	Task<List<TEntity>> GetAllAsync();
//	Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
//	void Add(TEntity entity);
//	void Update(TEntity entity);
//	void Remove(TEntity entity);
//}
//public interface ICustomerRepository  : IRepository_New<Customer>
//{ }

//public class Repository_New<TEntity> : IRepository_New<TEntity> where TEntity : class
//{
//	private readonly DbSet<TEntity> _dbSet;

//	//context
//	private readonly ContextDemo _dbContext;

//	public Repository_New(ContextDemo context)
//	{
//		_dbContext = context;
//		_dbSet = _dbContext.Set<TEntity>();
//	}

//	public async Task<TEntity> GetByIdAsync(int id)
//	{
//		return await _dbSet.FindAsync(id);
//	}

//	public async Task<List<TEntity>> GetAllAsync()
//	{
//		return await _dbSet.ToListAsync();
//	}

//	public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
//	{
//		return await _dbSet.Where(predicate).ToListAsync();
//	}

//	public void Add(TEntity entity)
//	{
//		_dbSet.Add(entity);
//		dbContext.SaveChanges();
//	}

//	public void Update(TEntity entity)
//	{
//		_dbSet.Update(entity);
//	}

//	public void Remove(TEntity entity)
//	{
//		_dbSet.Remove(entity);
//	}
//}

//public class CustomerRepository : Repository_New<Customer>, ICustomerRepository
//{
//	public CustomerRepository(ContextDemo context) : base(context)
//	{
//	}
//}




//public interface IUnitOfWork_New
//{
//	Task<int> SaveChangesAsync();
//	Task BeginTransactionAsync();
//	Task CommitAsync();
//	Task RollbackAsync();
//	//IRepository_New<TEntity> Repository_New<TEntity>() where TEntity : class;
//}

//public class UnitOfWork_New : IUnitOfWork_New
//{
//	//private readonly DbContext _dbContext;
//	private readonly IApplicationDbContext _dbContext;
//	private readonly Dictionary<Type, object> _repositories;

//	public UnitOfWork_New(/*DbContext dbContext*/IApplicationDbContext context)
//	{
//		//_dbContext = dbContext;
//		_dbContext = context;
//		//_repositories = new Dictionary<Type, object>();
//	}

//	public async Task<int> SaveChangesAsync()
//	{
//		return await _dbContext.SaveChangesAsync();
//	}

//	public async Task BeginTransactionAsync()
//	{
//		//await _dbContext.Database.BeginTransactionAsync();
//	}

//	public async Task CommitAsync()
//	{
//		//await _dbContext.Database.CurrentTransaction.CommitAsync();
//	}

//	public async Task RollbackAsync()
//	{
//		//await _dbContext.Database.CurrentTransaction.RollbackAsync();
//	}

//	public void Dispose()
//	{
//		//_dbContext.Dispose();
//	}

//	//public IRepository_New<TEntity> Repository_New<TEntity>() where TEntity : class
//	//{
//	//	if (_repositories.ContainsKey(key: typeof(TEntity)))
//	//	{
//	//		return (_repositories[key: typeof(TEntity)] as IRepository_New<TEntity>)!;
//	//	}

//	//	var repository = new Repository_New<TEntity>(_dbContext);
//	//	_repositories.Add(key: typeof(TEntity), value: repository);
//	//	return repository;
//	//}
//}




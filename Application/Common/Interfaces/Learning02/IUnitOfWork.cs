using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Learning02;

public interface IUnitOfWork : IDisposable
{
	ICustomerRepository Customers { get; }
	IOrderRepository Orders { get; }
	IProductRepository Products { get; }
	Task<int> CompleteAsync();
	Task DisposeAsync();
}


public interface IGenericRepository<T> where T : class
{
	Task<T> GetAsync(int id);
	Task<IEnumerable<T>> GetAll();
	Task AddAsync(T entity);
	Task Delete(int id);
	Task Update(int id, T entity);
}


public interface ICustomerRepository : IGenericRepository<Customer>
{

}

public interface IOrderRepository : IGenericRepository<Order>
{

}

public interface IProductRepository : IGenericRepository<Product>
{

}
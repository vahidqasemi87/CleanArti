﻿using Application.Common.Interfaces.Learning02;
using Persistence.Context;
using System;
using System.Threading.Tasks;

namespace Persistence.UOF;

public class UnitOfWork : IUnitOfWork
{
	private readonly ApplicationDbContext _context;
	public ICustomerRepository Customers { get; }

	public IOrderRepository Orders { get; }

	public IProductRepository Products { get; }



	public UnitOfWork(
		ApplicationDbContext context, ICustomerRepository customerRepository, IOrderRepository orderRepository, IProductRepository productRepository)
	{
		_context = context;
		Customers = customerRepository;
		Orders = orderRepository;
		Products = productRepository;

	}

	public async Task<int> CompleteAsync()
	{
		return await _context.SaveChangesAsync();
	}

	public async Task DisposeAsync()
	{
		await DisposeAsync();
		GC.SuppressFinalize(this);
	}
	protected virtual async void Dispose(bool disposing)
	{
		if (disposing)
		{
			await _context.DisposeAsync();
		}
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
}

using Application.Interfaces;
using Domain.DTOs.Responses.Customers;
using Domain.DTOs.Responses.Orders;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.Customers.CreateCustomer;

public class CreateCustomerCommand : IRequest<CreateCustomerDto>
{
	public CreateCustomerCommand()
	{
		Orders = new List<Order>();
	}
	public string? Username { get; set; }
	public string? Password { get; set; }
	public string? Family { get; set; }
	public string? Name { get; set; }
	public string? Mobile { get; set; }
	public string? Address { get; set; }
	public IList<Order> Orders { get; set; }
}

public static class CreateCustomerCommandExtension
{
	public static Customer MapTo(this CreateCustomerCommand command)
	{
		var customer = new Customer
		{
			Address = command.Address,
			Family = command.Address,
			Name = command.Name,
			Mobile = command.Mobile,
			Orders = command.Orders,
			Password = command.Password,
			Username = command.Username,
		};
		return customer;
	}
}

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerDto>
{
	private readonly IApplicationDbContext _context;
	public CreateCustomerCommandHandler(IApplicationDbContext context)
	{
		_context = context;
	}
	public async Task<CreateCustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
	{
		var customer = request.MapTo();
		var entityEntry =
			await _context.Customers.AddAsync(customer);

		var resultId = await _context.SaveChangesAsync();

		return new CreateCustomerDto(id:resultId);
	}
}
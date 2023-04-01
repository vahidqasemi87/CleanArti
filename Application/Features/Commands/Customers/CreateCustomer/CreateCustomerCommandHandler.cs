using Application.Configuration;
using Application.Features.Commands.Orders.CreateOrder;
using Application.Features.Commands.Products.CreateProduct;
using Application.FluentValidations.Customers;
using Application.Interfaces;
using Domain.DTOs.Responses.Customers;
using Domain.DTOs.Responses.Orders;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Step02;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.Customers.CreateCustomer;

public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, CreateCustomerDto>// IRequestHandler<CreateCustomerCommand, CreateCustomerDto>
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
		var orderId = await _context.SaveChangesAsync();

		return new  CreateCustomerDto(id: orderId);
	}
}
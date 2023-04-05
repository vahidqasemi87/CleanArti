

using Application.Interfaces;
using AutoMapper;
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

namespace Application.Features.Customers.Command.CreateCustomer;

public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, CreateCustomerDto>// IRequestHandler<CreateCustomerCommand, CreateCustomerDto>
{
	private readonly IApplicationDbContext _context;
	private readonly IMapper _mapper;

	public CreateCustomerCommandHandler(IApplicationDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	public async Task<CreateCustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
	{
		//var customer = request.MapTo();

		var customer = new Customer();


		customer =
			_mapper.Map<Customer>(request);


		var entityEntry =
			await _context.Customers.AddAsync(customer);
		var orderId = await _context.SaveChangesAsync();

		return new CreateCustomerDto(id: orderId);
	}
}
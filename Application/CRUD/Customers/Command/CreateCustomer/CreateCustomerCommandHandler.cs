

using Application.Common.Interfaces.Learning;
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
	private readonly IUnitOfWork_New _unitOfWork_New;
	private readonly IRepository_New<Customer> _repository_New;
	private readonly IMapper _mapper;

	public CreateCustomerCommandHandler( IMapper mapper,
		IUnitOfWork_New unitOfWork_New, IRepository_New<Customer> repository_New)
	{
		_mapper = mapper;

		_unitOfWork_New = unitOfWork_New;
		_repository_New = repository_New;

	}

	public async Task<CreateCustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
	{
		

		var customer = new Customer();


		customer =
			_mapper.Map<Customer>(request);


		

		_repository_New.Add(customer);
		var orderId = await _unitOfWork_New.SaveChangesAsync();

		

		return new CreateCustomerDto(id: orderId);
	}
}
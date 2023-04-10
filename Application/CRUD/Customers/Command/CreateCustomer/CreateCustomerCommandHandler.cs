using Application.Common.Interfaces.Learning02;
using AutoMapper;
using Domain.DTOs.Responses.Customers;
using Domain.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using MediatR;
using Step02;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Customers.Command.CreateCustomer;

public class CreateCustomerCommandHandler :
	IRequestHandler<CreateCustomerCommand, CreateCustomerDto>
{
	private IValidator<CreateCustomerCommand> _validator;
	private readonly IUnitOfWork _unitOfWork;
	private readonly ICustomerRepository _customerRepository;
	private readonly IMapper _mapper;




	public CreateCustomerCommandHandler(
		IMapper mapper, IUnitOfWork unitOfWork, ICustomerRepository customerRepository,IValidator<CreateCustomerCommand> validator
		)
	{
		_mapper = mapper;
		_validator = validator;
		_unitOfWork = unitOfWork;
		_customerRepository = customerRepository;

	}
	public async Task<CreateCustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
	{

		ValidationResult result =
			await _validator.ValidateAsync(request);
		if (!result.IsValid)
		{
			//Error
		}

		var customer = new Customer();


		customer =
			_mapper.Map<Customer>(request);




		await _customerRepository.AddAsync(customer);
		var orderId = await _unitOfWork.CompleteAsync();



		return new CreateCustomerDto(id: orderId);
	}
}
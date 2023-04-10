using Application.Common.Interfaces.Learning02;
using AutoMapper;
using Domain.DTOs.Responses.Customers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Customers.Command.CreateCustomer;

public class CreateCustomerCommandHandler :
	 //ICommandHandler<CreateCustomerCommand, CreateCustomerDto>
	 IRequestHandler<CreateCustomerCommand, CreateCustomerDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly ICustomerRepository _customerRepository;
	private readonly IMapper _mapper;




	public CreateCustomerCommandHandler(
		IMapper mapper, IUnitOfWork unitOfWork, ICustomerRepository customerRepository
		)
	{
		_mapper = mapper;

		_unitOfWork = unitOfWork;
		_customerRepository = customerRepository;

	}

	public async Task<CreateCustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
	{


		var customer = new Customer();


		customer =
			_mapper.Map<Customer>(request);




		await _customerRepository.AddAsync(customer);
		var orderId = await _unitOfWork.CompleteAsync();



		return new CreateCustomerDto(id: orderId);

	}
}
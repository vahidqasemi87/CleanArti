using Application.Interfaces;
using Domain.DTOs.Responses.Customers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.Customers.CreateCustomer;

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

		return new CreateCustomerDto(id: resultId);
	}
}
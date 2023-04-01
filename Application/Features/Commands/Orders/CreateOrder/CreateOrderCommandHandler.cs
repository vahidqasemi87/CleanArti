using Application.Interfaces;
using Domain.DTOs.Responses.Orders;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.Orders.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderDto>
{
	private readonly IApplicationDbContext _context;
	public CreateOrderCommandHandler(IApplicationDbContext context)
	{
		_context = context;
	}
	public async Task<CreateOrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
	{
		var order =
			request.MapTo();

		var customer=_context.Customers.Where(w=>w.Id==request.CustomerId).FirstOrDefault();

		if (customer != null)
			order.Customer = customer;

		var entityEntry = 
			await _context.Orders.AddAsync(order);

		var orderId =  await _context.SaveChangesAsync();

		return new CreateOrderDto(id: orderId);
	}
}
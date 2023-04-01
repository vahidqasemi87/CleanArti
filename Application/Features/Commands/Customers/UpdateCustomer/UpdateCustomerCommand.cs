using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.Customers.UpdateCustomer;

public class UpdateCustomerCommand : IRequest<Customer>
{
	public UpdateCustomerCommand()
	{
		Orders = new List<Order>();
	}
	public int Id { get; set; }
	public string? Username { get; set; }
	public string? Password { get; set; }
	public string? Family { get; set; }
	public string? Name { get; set; }
	public string? Mobile { get; set; }
	public string? Address { get; set; }
	public IList<Order> Orders { get; set; }
}

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
{
	private readonly IApplicationDbContext _context;
	public UpdateCustomerCommandHandler(IApplicationDbContext context)
	{
		_context = context;
	}
	public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
	{
		var findedCustomer = await _context.Customers.Where(w => w.Id == request.Id)
			.FirstOrDefaultAsync();

		if (findedCustomer != null)
		{
			findedCustomer.Name = request.Name;
			findedCustomer.Family = request.Family;
			findedCustomer.Address = request.Address;
			findedCustomer.Mobile = request.Mobile;
			findedCustomer.Password = request.Password;
			//findedCustomer.Orders = request.Orders;
			findedCustomer.Username = request.Username;

			var info = await _context.SaveChangesAsync();
			return findedCustomer;
		}
		return null;
	}
}
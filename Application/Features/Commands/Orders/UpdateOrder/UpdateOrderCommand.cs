using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.Orders.UpdateOrder;

public class UpdateOrderCommand : IRequest<int>
{
	public UpdateOrderCommand()
	{
		Customer = new Customer();
	}
	public int Id { get; set; }
	public DateTime? OrderDate { get; set; }
	public bool IsPayed { get; set; } = false;
	public bool IsSend { get; set; } = false;
	public string? PaymentCode { get; set; }
	public Customer Customer { get; set; }
}

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
{
	private readonly IApplicationDbContext _context;
	public UpdateOrderCommandHandler(IApplicationDbContext context)
	{
		_context = context;
	}
	public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
	{
		var findedOrder = await _context.Orders.Where(w => w.Id == request.Id)
			.FirstOrDefaultAsync();
		if (findedOrder != null)
		{
			findedOrder.IsPayed = request.IsPayed;
			findedOrder.IsSend = request.IsSend;
			findedOrder.OrderDate = request.OrderDate;
			findedOrder.PaymentCode = request.PaymentCode;
			findedOrder.Customer = request.Customer;

			var finalId =  await _context.SaveChangesAsync();
			return finalId;
		}
		return 0;
	}
}

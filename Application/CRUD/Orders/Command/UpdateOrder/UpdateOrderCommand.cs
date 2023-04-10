using Application.Common.Interfaces.Learning02;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Orders.Command.UpdateOrder;

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
	private readonly IUnitOfWork _unitOfWork;
	private readonly IOrderRepository _orderRepository;
	public UpdateOrderCommandHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository)
	{
		_unitOfWork = unitOfWork;
		_orderRepository = orderRepository;
	}
	public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
	{
		//var findedOrder = await _context.Orders.Where(w => w.Id == request.Id)
		//	.FirstOrDefaultAsync();

		var findedOrder =
			await _orderRepository.GetAsync(request.Id);

		if (findedOrder != null)
		{
			findedOrder.IsPayed = request.IsPayed;
			findedOrder.IsSend = request.IsSend;
			findedOrder.OrderDate = request.OrderDate;
			findedOrder.PaymentCode = request.PaymentCode;
			findedOrder.Customer = request.Customer;

			//var finalId = await _context.SaveChangesAsync();
			var finalId =
				await _unitOfWork.CompleteAsync();

			return finalId;
		}
		return 0;
	}
}

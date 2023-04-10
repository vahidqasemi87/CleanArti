using Application.Common.Interfaces.Learning02;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Orders.Command.DeleteOrder;

public class DeleteOrderCommand : IRequest<int>
{
	public int Id { get; set; }
}

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, int>
{
	private readonly IApplicationDbContext _context;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IOrderRepository _orderRepository;


	public DeleteOrderCommandHandler(IApplicationDbContext context,IUnitOfWork unitOfWork,IOrderRepository orderRepository)
	{
		_context = context;
		_unitOfWork = unitOfWork;
		_orderRepository = orderRepository;
	}
	public async Task<int> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
	{
		var findedOrder = await _orderRepository.GetAsync(id:request.Id);

		//var findedOrder = await _context.Orders.Where(w => w.Id == request.Id)
		//	.FirstOrDefaultAsync();
		if (findedOrder != null)
		{
			 await _orderRepository.Delete(findedOrder.Id);
			//var entityEntry = _context.Orders.Remove(findedOrder);
			//var finalId = await _context.SaveChangesAsync();
			var finalId =  await _unitOfWork.CompleteAsync();
			return finalId;
		}
		return 0;

	}
}
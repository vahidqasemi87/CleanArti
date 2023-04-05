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
    public DeleteOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var findedOrder = await _context.Orders.Where(w => w.Id == request.Id)
            .FirstOrDefaultAsync();
        if (findedOrder != null)
        {
            var entityEntry = _context.Orders.Remove(findedOrder);
            var finalId = await _context.SaveChangesAsync();
            return finalId;
        }
        return 0;

    }
}
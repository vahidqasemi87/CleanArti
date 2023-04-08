using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Customers.Command.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, int>
{
	private readonly IApplicationDbContext _context;
	public DeleteCustomerCommandHandler(IApplicationDbContext context)
	{
		_context = context;
	}
	public async Task<int> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
	{
		var findCustomer =
			await _context.Customers.Where(w => w.Id == request.Id).FirstOrDefaultAsync();
		if (findCustomer != null)
		{
			var entityEntry = _context.Customers.Remove(findCustomer);
			var resultId = await _context.SaveChangesAsync();
			return resultId;

		}
		return 0;

	}
}

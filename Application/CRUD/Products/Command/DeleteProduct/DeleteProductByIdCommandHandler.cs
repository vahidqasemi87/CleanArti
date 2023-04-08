using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Command.DeleteProduct;

public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
{
	private readonly IApplicationDbContext _context;
	public DeleteProductByIdCommandHandler(IApplicationDbContext context)
	{
		_context = context;
	}
	public async Task<int> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
	{
		var findedProduct =
			await _context.Products.Where(w => w.Id == request.Id).FirstOrDefaultAsync();

		if (findedProduct != null)
		{
			_context.Products.Remove(findedProduct);
			var finalId =
				await _context.SaveChangesAsync();
			return finalId;
		}
		return 0;
	}
}
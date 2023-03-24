using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.Products.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
{
	private readonly IApplicationDbContext _context;
	public UpdateProductCommandHandler(IApplicationDbContext context)
	{
		_context = context;
	}
	public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
	{
		var findedProduct = await _context.Products.Where(w => w.Id == request.Id)
			.FirstOrDefaultAsync();

		if (findedProduct == null)
			return default;

		findedProduct.Barcode = request.Barcode;
		findedProduct.Name = request.Name;
		findedProduct.Description = request.Description;
		findedProduct.Rate = request.Rate;


		await _context.SaveChangesAsync();
		return findedProduct.Id;
	}
}

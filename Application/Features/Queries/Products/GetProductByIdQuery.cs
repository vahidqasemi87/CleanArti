using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.Products;

public class GetProductByIdQuery : IRequest<Product>
{
	public int Id { get; set; }
}


public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
	private readonly IApplicationDbContext _context;
	public GetProductByIdQueryHandler(IApplicationDbContext context)
	{
		_context = context;
	}
	public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
	{
		var findedProduc =
			await _context.Products.Where(w => w.Id == request.Id).FirstOrDefaultAsync();

		if (findedProduc == null) 
			return null;


		return findedProduc;
	}
}

using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.Products;

public class GetAllProductQuery : IRequest<IList<Product>>
{
}


public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IList<Product>>
{
	private readonly IApplicationDbContext _context;
	public GetAllProductQueryHandler(IApplicationDbContext context)
	{
		_context = context;
	}
	public async Task<IList<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
	{
		var listProduct = await _context.Products.AsNoTracking().ToListAsync();
		return listProduct;
	}
}

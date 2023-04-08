using Application.Common.Interfaces.Learning02;
using Domain.Entities;
using Persistence.Commons;
using Persistence.Context;

namespace Persistence.Products;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
	public ProductRepository(ApplicationDbContext context) : base(context)
	{
	}
}

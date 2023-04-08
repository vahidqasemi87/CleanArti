using Application.Common.Interfaces.Learning02;
using Domain.Entities;
using Persistence.Commons;
using Persistence.Context;

namespace Persistence.Orders;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
	public OrderRepository(ApplicationDbContext context) : base(context)
	{
	}
}

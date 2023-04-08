using Application.Common.Interfaces.Learning02;
using Domain.Entities;
using Persistence.Commons;
using Persistence.Context;

namespace Persistence.Customers;

public class CustomersRepository : GenericRepository<Customer>, ICustomerRepository
{
	public CustomersRepository(ApplicationDbContext context) : base(context)
	{
	}


}

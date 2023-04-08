using MediatR;

namespace Application.Features.Customers.Command.DeleteCustomer;

public class DeleteCustomerCommand : IRequest<int>
{
	public int Id { get; set; }
}

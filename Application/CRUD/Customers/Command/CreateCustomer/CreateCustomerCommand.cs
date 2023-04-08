using Domain.DTOs.Responses.Customers;
using MediatR;

namespace Application.Features.Customers.Command.CreateCustomer;

public class CreateCustomerCommand :
	//ICommand<CreateCustomerDto>
	IRequest<CreateCustomerDto>
{
	public CreateCustomerCommand()
	{
		// Orders = new List<Order>();
	}
	public string? Username { get; set; }
	public string? Password { get; set; }
	public string? Family { get; set; }
	public string? Name { get; set; }
	public string? Mobile { get; set; }
	public string? Address { get; set; }
	public string? NationalCode { get; set; }
	//public IList<Order> Orders { get; set; }
}

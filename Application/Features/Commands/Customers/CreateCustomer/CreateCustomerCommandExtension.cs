using Domain.Entities;

namespace Application.Features.Commands.Customers.CreateCustomer;

public static class CreateCustomerCommandExtension
{
	public static Customer MapTo(this CreateCustomerCommand command)
	{
		var customer = new Customer
		{
			Address = command.Address,
			Family = command.Address,
			Name = command.Name,
			Mobile = command.Mobile,
			Orders = command.Orders,
			Password = command.Password,
			Username = command.Username,
		};
		return customer;
	}
}

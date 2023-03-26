using Domain.DTOs.Responses.Customers;
using Domain.DTOs.Responses.Orders;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Features.Commands.Customers.CreateCustomer;

public class CreateCustomerCommand : IRequest<CreateCustomerDto>
{
	public CreateCustomerCommand()
	{
		Orders = new List<Order>();
	}
	public string? Username { get; set; }
	public string? Password { get; set; }
	public string? Family { get; set; }
	public string? Name { get; set; }
	public string? Mobile { get; set; }
	public string? Address { get; set; }
	public IList<Order> Orders { get; set; }
}

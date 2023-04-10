using Application.Common.Base;
using Domain.DTOs.Responses.Orders;
using MediatR;
using System;

namespace Application.Features.Orders.Command.CreateOrder;

public class CreateOrderCommand : IRequest<CreateOrderDto>
	//ICommand<CreateOrderDto>
{
	public CreateOrderCommand(int customerId)
	{
		//Customer = new Customer();
		CustomerId = customerId;
	}
	public DateTime? OrderDate { get; set; }
	public bool IsPayed { get; set; } = false;
	public bool IsSend { get; set; } = false;
	public string? PaymentCode { get; set; }
	public int CustomerId { get; set; }
	public decimal Price { get; set; }
	//public Customer? Customer { get; set; }
}
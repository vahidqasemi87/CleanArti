using Domain.DTOs.Responses.Orders;
using Domain.Entities;
using MediatR;
using System;

namespace Application.Features.Commands.Orders.CreateOrder;

public class CreateOrderCommand : IRequest<CreateOrderDto>
{
	public CreateOrderCommand()
	{
		Customer = new Customer();
	}
	public DateTime? OrderDate { get; set; }
	public bool IsPayed { get; set; } = false;
	public bool IsSend { get; set; } = false;
	public string? PaymentCode { get; set; }
	public Customer? Customer { get; set; }
}
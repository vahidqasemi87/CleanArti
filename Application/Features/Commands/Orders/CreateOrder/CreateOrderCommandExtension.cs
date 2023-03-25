﻿using Domain.Entities;

namespace Application.Features.Commands.Orders.CreateOrder;

public static class CreateOrderCommandExtension
{
	public static Order MapTo(this CreateOrderCommand command)
	{
		var order = new Order
		{
			Customer = command.Customer,
			IsPayed = command.IsPayed,
			IsSend = command.IsPayed,
			OrderDate = command.OrderDate,
			PaymentCode = command.PaymentCode,
		};
		return order;
	}
}

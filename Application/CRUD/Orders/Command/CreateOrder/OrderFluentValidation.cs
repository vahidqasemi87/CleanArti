using Application.Features.Orders.Command.CreateOrder;
using FluentValidation;

namespace Application.CRUD.Orders.Command.CreateOrder;

public class OrderFluentValidation : AbstractValidator<CreateOrderCommand>
{
	public OrderFluentValidation()
	{
		RuleFor(c => c.IsPayed)
			.NotNull()
			.NotEmpty();

		RuleFor(c => c.IsSend)
			.NotNull()
			.NotEmpty();
	}
}
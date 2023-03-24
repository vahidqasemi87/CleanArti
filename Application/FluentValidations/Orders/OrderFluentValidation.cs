using Domain.Entities;
using FluentValidation;

namespace Application.FluentValidations.Orders;

public class OrderFluentValidation : FluentValidation.AbstractValidator<Order>
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
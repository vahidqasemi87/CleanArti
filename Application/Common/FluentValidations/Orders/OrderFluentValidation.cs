using Domain.Entities;
using FluentValidation;

namespace Application.Common.FluentValidations.Orders;

public class OrderFluentValidation : AbstractValidator<Order>
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
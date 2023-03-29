using Step01;
using FluentValidation;
using MediatR;

namespace Step04;

public sealed record UpdateUserCommand(int UserId, string FirstName, string LastName)
	: ICommand<Unit>
{
}


public sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
	public UpdateUserCommandValidator()
	{
		RuleFor(x => x.UserId).NotEmpty();

		RuleFor(x=>x.FirstName)
			.NotEmpty()
			.MaximumLength(100);

		RuleFor(x=>x.LastName)
			.NotEmpty()
			.MaximumLength(100);
	}
}
using Application.Features.Customers.Command.CreateCustomer;
using FluentValidation;
using System.Linq;
using System.Text.RegularExpressions;

namespace Application.CRUD.Customers.Command.CreateCustomer;


public class CustomerFluentValidation :
	//AbstractValidator<CustomerCreateCommand> 
	AbstractValidator<CreateCustomerCommand>
{
	public CustomerFluentValidation()
	{
		RuleFor(c => c.Username)
			.NotEmpty()
			.WithMessage("Usernme is not empty.")
			.NotNull()
			.WithMessage("Username is not null.")
			.Must(ValidStringNotEmpty)
			.WithMessage("Custome error !!!");




		RuleFor(expression: c => c.Name)
			.Length(min: 3, max: 50)
			.WithMessage(errorMessage: "Name range is 3 to 50.")
			.NotNull()
			.WithMessage(errorMessage: "Name is requierd")
			.NotEmpty();

		RuleFor(expression: c => c.Password).
			NotEmpty()
			.NotNull()
			.Length(min: 8, max: 16)
			.WithMessage(errorMessage: "password length between 8 .. 16 charachter");

		RuleFor(expression: x => x.Password!).Must(predicate: ValidatePassword);
	}

	private bool ValidatePassword(string pw)
	{
		var lowecase = new Regex("[a-z]+");
		var uppercase = new Regex("[A-Z]+");
		var digit = new Regex("(\\d)+");
		var symbol = new Regex("(\\W)+");

		var result =
			lowecase.IsMatch(pw)
			&&
			uppercase.IsMatch(pw)
			&&
			symbol.IsMatch(pw)
			&&
			digit.IsMatch(pw);

		return result;
	}
	private bool ValidStringNotEmpty(string? input)
	{
		if (string.IsNullOrWhiteSpace(input)) return true;

		input =
				input.Replace(" ", string.Empty);

		// All -> Is Extension Method -> using System.Linq;
		bool result =
			input.All(char.IsLetter);

		return result;

	}
}

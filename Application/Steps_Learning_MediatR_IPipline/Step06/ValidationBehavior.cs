using FluentValidation;
using Step01;
using Step05;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Step06;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : class, ICommand<TResponse>
{

	private readonly IEnumerable<IValidator<TRequest>> _validator;
	public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
	{
		_validator = validators;
	}



	public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, MediatR.RequestHandlerDelegate<TResponse> next)
	{
		if (!_validator.Any())
		{
			return await next();
		}

		var context =
			new ValidationContext<TRequest>(instanceToValidate: request);

		var errorsDictionary = _validator
			.Select(x => x.Validate(context))
			.SelectMany(x => x.Errors)
			.Where(x => x != null)
			.GroupBy(
				x => x.PropertyName,
				x => x.ErrorMessage,
				(propertyName, errorMessages) => new
				{
					Key = propertyName,
					Values = errorMessages.Distinct().ToArray()
				})
			.ToDictionary(x => x.Key, x => x.Values);

		if (errorsDictionary.Any())
		{
			await Console.Out.WriteLineAsync("Error !!!!");

		}
		return await next();
	}
}

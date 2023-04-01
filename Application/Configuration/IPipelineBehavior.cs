using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Configuration;


public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : IRequest<TResponse>
{

	private readonly IEnumerable<IValidator<TRequest>> _validators;
	public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
	{
		_validators = validators;
	}

	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		var validateCheck = _validators.Any();

		if ( ! validateCheck )
		{
			return await next();
		}

		var context =
			new ValidationContext<TRequest>(instanceToValidate: request);

		var errorsDictionary = _validators
			.Select(selector: x => x.Validate(context))
			.SelectMany(selector: x => x.Errors)
			.Where(predicate: x => x != null)
			.GroupBy(
				keySelector: x => x.PropertyName,
				elementSelector: x => x.ErrorMessage,
				resultSelector: (propertyName, errorMessages) => new
				{
					Key = propertyName,
					Values = errorMessages.Distinct().ToArray()
				})
			.ToDictionary(x => x.Key, x => x.Values);

		if (errorsDictionary.Any())
		{
			//await Console.Out.WriteLineAsync(value: "Error !!!!");

		}
		return await next();




	}



	//public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, MediatR.RequestHandlerDelegate<TResponse> next)
	//{
	//	if (!_validator.Any())
	//	{
	//		return await next();
	//	}

	//	var context =
	//		new ValidationContext<TRequest>(instanceToValidate: request);

	//	var errorsDictionary = _validator
	//		.Select(x => x.Validate(context))
	//		.SelectMany(x => x.Errors)
	//		.Where(x => x != null)
	//		.GroupBy(
	//			x => x.PropertyName,
	//			x => x.ErrorMessage,
	//			(propertyName, errorMessages) => new
	//			{
	//				Key = propertyName,
	//				Values = errorMessages.Distinct().ToArray()
	//			})
	//		.ToDictionary(x => x.Key, x => x.Values);

	//	if (errorsDictionary.Any())
	//	{
	//		await Console.Out.WriteLineAsync(value: "Error !!!!");

	//	}
	//	return await next();
	//}

	//public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	//{
	//	throw new NotImplementedException();
	//}
}
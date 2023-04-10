using Application.Common.Z;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Behavious;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : class, IRequest<TResponse>
{
	private readonly IEnumerable<IValidator<TRequest>> _validators;
	private readonly ILogger<TRequest> _logger;

	public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<TRequest> logger)
	{
		_validators = validators;
		_logger = logger;
	}


	// سوال؟
	// چرا همیشه در اینجا مقدار درست به ما پاس می دهد و هیچ مقدار غلطی را پیدا نمی کند؟
	//  همیشه خط شماره 33 اجرا می شه !!
	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		if (!_validators.Any())
		{
			return await next();
		}
		_logger.LogDebug(EventIds.ValidationStart, "There is {ValidatorCount} validators for {RequestName}", _validators.Count(), request.GetType().Name);
		var context = new ValidationContext<TRequest>(request);


		var validationResults = new List<FluentValidation.Results.ValidationResult>();

		foreach (var validator in _validators)
		{
			var r = validator.Validate(context);
			var f = r.RuleSetsExecuted;
			validationResults.Add(r);
		}

		var errorNotifications = validationResults
			.SelectMany(x => x.Errors)
			.Where(x => x != null)
			.DistinctBy(x => x.ErrorMessage);


		if (errorNotifications.Any())
		{
			var error = errorNotifications.Select(x => new { x.ErrorCode, x.ErrorMessage }).ToList();

			_logger.LogWarning(EventIds.ValidationEnd, "Validations failed for {RequestName}", request.GetType().Name);

			var notifications = errorNotifications.Select(x => new Notification(x.ErrorCode, x.ErrorMessage));

			var t = typeof(TResponse);

			if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Result<>))
			{
				var constructed = typeof(Result<>).MakeGenericType(t.GenericTypeArguments);
				var args = new object[] { null, notifications };
				var instance = Activator.CreateInstance(constructed, args);

				return (TResponse)instance!;
			}

			else if (t == typeof(Result))
			{
				Type constructed;
				object[] args;
				constructed = typeof(Result);
				args = new object[] { notifications };
				var instance = Activator.CreateInstance(constructed, args);
				return (TResponse)instance!;
			}
			else
			{
				throw new FluentValidation.ValidationException(errorNotifications);
			}
		}


		_logger
			.LogDebug(
			   eventId: EventIds.ValidationEnd,
			message: "The request name:'{RequestName}' was valid",
			args: request.GetType().Name);


		return await next();
	}
}

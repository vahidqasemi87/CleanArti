using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Base
{
	public abstract class RequestHandlerBase
	{
		//protected Result<T> Ok<T>(T value) => Results.Ok(value);
		//protected Result Ok() => Results.Ok();
		//protected Result Faile(params Notification[] notifications) => Results.Faile(notifications);
		//protected Result Faile(IEnumerable<Notification> notifications) => Results.Faile(notifications);
		//protected Result Faile(ValidationResult validationResult) => Faile(validationResult.Errors.Select(x => new Notification(x.ErrorCode, x.ErrorMessage)));
		//protected Result<T> Faile<T>(params Notification[] notifications) => Results.Faile<T>(notifications);
		//protected Result<T> Faile<T>(IEnumerable<Notification> notifications) => Results.Faile<T>(notifications);
		//protected Result<T> Faile<T>(ValidationResult validationResult) => Faile<T>(validationResult.Errors.Select(x => new Notification(x.ErrorCode, x.ErrorMessage)));
		//protected decimal Percent(int total, int current) => Math.Round((decimal)current / total * 100, 2);
	}
}

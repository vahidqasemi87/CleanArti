using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Common.Z;
[SwaggerSchema(Title = "ساختار خطا", Description = "متن و کد خطا در این ساختار ارائه میشود")]
[Serializable]

public class Notification
{
	internal Notification()
	{

	}
	public Notification(string errorCode, string message, bool isInfrastructure = false)
	{
		ErrorCode = errorCode;
		Message = message;
		IsInfrastructure = isInfrastructure;
	}
	public Notification(string errorCode, Type resourceType, bool isInfrastructure = false)
	{
		ErrorCode = errorCode;
		Message = resourceType.GetTypeInfo()
			.GetDeclaredMethods("get_" + errorCode)!
			.FirstOrDefault()!
			.Invoke(null, null)!
			.ToString()!;

		IsInfrastructure = isInfrastructure;
	}

	[SwaggerSchema(Title ="کد خطا")]
    public string ErrorCode { get; set; }

	[SwaggerSchema(Title = "متن خطا")]
    public string Message { get; set; }

	[JsonIgnore]
    public bool IsInfrastructure { get; set; }
}

public static class Results
{
}
public class Result
{
	public bool IsSuccess => Errors == null || !Errors.Any();
	public bool IsFailed => !IsSuccess;

	[Newtonsoft.Json.JsonProperty]
	public IEnumerable<Notification> Errors { get; private set; }
	public Result(IEnumerable<Notification> notifications) => Errors = notifications;
	private Result()
	{
		Errors = new List<Notification>();
	}
}

public class Result<T> : Result
{
	public T Value { get; set; }
	public Result(T value, IEnumerable<Notification> notifications) : base(notifications) => Value = value;

}

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Threading.Tasks;


namespace Step07;
//Create Middleware

internal sealed class ExceptionHandlingMiddleware : IMiddleware
{
	private readonly ILogger<ExceptionHandlingMiddleware> _logger;

	public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;

	public async Task InvokeAsync(HttpContext context, RequestDelegate next)
	{
		try
		{
			await next(context);
		}
		catch (Exception e)
		{
			_logger.LogError(e, e.Message);
			await HandleExceptionAsync(context, e);
		}
	}

	private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
	{
		var statusCode = GetStatusCode(exception);

		var response = new
		{
			title = GetTitle(exception),
			status = statusCode,
			detail = exception.Message,
			errors = GetErrors(exception)
		};

		httpContext.Response.ContentType = "application/json";

		httpContext.Response.StatusCode = statusCode;

		await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
	}
	public static int GetStatusCode(Exception exception)
	{
		var status400BadRequest = StatusCodes.Status400BadRequest;
		var status404NotFound = StatusCodes.Status404NotFound;
		var status422UnprocessableEnttity = StatusCodes.Status422UnprocessableEntity;

		if (exception.HResult == status400BadRequest) ;

		switch (exception.HResult)
		{
			case StatusCodes.Status400BadRequest:
				return status400BadRequest;
			case StatusCodes.Status404NotFound:
				return status404NotFound;
			case StatusCodes.Status422UnprocessableEntity:
				return status422UnprocessableEnttity;
		}
		return 500;

	}
	//private static int GetStatusCode(Exception exception) =>
	//	exception switch
	//	{
	//		ExceptionBadRequestException => StatusCodes.Status400BadRequest,
	//		NotFoundException => StatusCodes.Status404NotFound,
	//		ValidationException => StatusCodes.Status422UnprocessableEnttity,
	//		_ => StatusCodes.Status500InternalServerError
	//	};


	private static string GetTitle(Exception exception)
	{
		ApplicationException applicationException = new ApplicationException();

		var aaa = applicationException.Message;

		var r =
			exception.Message == aaa ? applicationException.Message : "Server Error";

		return r;


	}


	//private static string GetTitle(Exception exception) =>
	//	exception switch
	//	{
	//		ApplicationException applicationException => applicationException.Title,
	//		_ => "Server Error"
	//	};

	private static IReadOnlyDictionary<string, string[]> GetErrors(Exception exception)
	{
		IReadOnlyDictionary<string, string[]> errors = null;

		if (exception is ValidationException validationException)
		{
			//errors = validationException.Value;
		}

		return errors;
	}
}

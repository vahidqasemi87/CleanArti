using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.Infrastructure.Middlewares;
public class ErrorHandlingMiddleware
{
	private readonly RequestDelegate next;
	private readonly ILogger logger;

	public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
	{
		this.next = next;
		this.logger = logger;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
			logger.LogError(exception: ex, message: "Unhandled exception");

			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			context.Response.ContentType = "application/json";

			var response = JsonConvert.SerializeObject(new { error = ex.Message });
			await context.Response.WriteAsync(response);
		}
	}
}
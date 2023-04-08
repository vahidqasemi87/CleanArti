

using IdentityDemo.Command.UserAggregate;
using IdentityDemo.Contracts;
using IdentityDemo.Contracts.UserAggregate;
using IdentityDemo.Domain;
using IdentityDemo.Domain.UserAggregate;
using IdentityDemo.Infrastructurs.Context;
using IdentityDemo.Infrastructurs.Data;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityDemo;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers();


		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

		builder.Services.AddSwaggerGen();
		builder.Services.AddEndpointsApiExplorer();







		/*
		  Unable to resolve service for type 'IdentityDemo.Contracts.UserAggregate.IUserServiceCommand' while attempting to activate 'IdentityDemo.Controllers.IdentityController'.
			 at Microsoft.Extensions.DependencyInjection.ActivatorUtilities.GetService(IServiceProvider sp, Type type, Type requiredBy, Boolean isDefaultParameterRequired)
			 at lambda_method10(Closure, IServiceProvider, Object[])
			 at Microsoft.AspNetCore.Mvc.Controllers.ControllerFactoryProvider.<>c__DisplayClass6_0.<CreateControllerFactory>g__CreateController|0(ControllerContext			controllerContext)
			 at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
			 at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()
--			- End of stack trace from previous location ---
			 at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|20_0(ResourceInvoker invoker, Task lastTask, State next, Scope	scope,		Object state, Boolean isCompleted)
			 at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
			 at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
			 at Microsoft.AspNetCore.Routing.EndpointMiddleware.<Invoke>g__AwaitRequestTask|6_0(Endpoint endpoint, Task requestTask, ILogger logger)
			 at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)
			 at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.Invoke(HttpContext context)
			 at Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIMiddleware.Invoke(HttpContext httpContext)
			 at Swashbuckle.AspNetCore.Swagger.SwaggerMiddleware.Invoke(HttpContext httpContext, ISwaggerProvider swaggerProvider)
			 at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddlewareImpl.Invoke(HttpContext context)
		 */



		//--> Error 500
		//'Some services are not able to be constructed
		//(Error while validating the service descriptor
		//'ServiceType: IdentityDemo.Contracts.UserAggregate.IUserServiceCommand Lifetime:
		//Scoped ImplementationType: 






		#region [Identity]




		builder.Services.AddDbContext<IdentityServerDbContext>(optionsAction: option =>
		{
			option.UseSqlServer(connectionString: builder.Configuration.GetConnectionString(name: "IdentityConnection"));
		});

		#endregion

		builder.Services.AddAuthentication();

		builder.Services.AddTransient<IUnitOfWord, UnitOfWork>();


		builder.Services.AddScoped<IUserServiceCommand, UserServiceCommand>();

		//builder.Services.AddAuthentication(options =>
		//{
		//	options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
		//	options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
		//	options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
		//});

		builder.Services.AddIdentity<User, Role>()
		.AddDefaultTokenProviders()
		.AddEntityFrameworkStores<IdentityServerDbContext>();


		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseCors(delegate (CorsPolicyBuilder builder)
		{
			builder.AllowAnyOrigin();
			builder.AllowAnyHeader();
			builder.AllowAnyMethod();
			builder.WithExposedHeaders("Content-Disposition");
		});

		app.UseHttpsRedirection();

		app.UseAuthentication();
		app.UseAuthorization();


		app.MapControllers();

		app.Run();
	}
}
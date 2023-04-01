using Application.Configuration;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Application.Features.Commands.Customers.CreateCustomer;
using Domain.DTOs.Responses.Customers;

namespace Application;

public static class DependencyInjection
{
	//IServiceCollection -> Microsoft.Extensions.DependencyInjection
	public static void AddApplication(this IServiceCollection services)
	{
		services.AddMediatR(assemblies: System.Reflection.Assembly.GetExecutingAssembly());


		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
		
		//services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CreateCustomerValidation));


	}
}
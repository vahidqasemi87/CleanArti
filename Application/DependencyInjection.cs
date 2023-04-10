
using Application.Common.Behavious;
using Application.Common.Mappings;
using Application.CRUD.Customers.Command.CreateCustomer;
using Application.CRUD.Orders.Command.CreateOrder;
using Application.CRUD.Products.Command.CreateProduct;
using Application.Features.Customers.Command.CreateCustomer;
using Application.Features.Orders.Command.CreateOrder;
using Application.Features.Products.Command.CreateProduct;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
	//IServiceCollection -> Microsoft.Extensions.DependencyInjection
	public static void AddApplication(this IServiceCollection services)
	{
		services.AddMediatR(options =>
		{
			options.RegisterServicesFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
		});


		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


		//****
		//services.AddDbContext<ContextDemo>();
		//****

		services.AddScoped<CalculateFinalPrice>();

		services.AddAutoMapper(assemblies: System.Reflection.Assembly.GetExecutingAssembly());

		services.AddScoped<IValidator<CreateCustomerCommand>, CustomerFluentValidation>();
		services.AddScoped<IValidator<CreateProductCommand>, ProductFluentValidation>();
		services.AddScoped<IValidator<CreateOrderCommand>, OrderFluentValidation>();


		#region [Config Automaspper]
		var mapperConfig =
			new MapperConfiguration(mc => mc.AddProfile(new MapperProfile()));
		IMapper mapper = mapperConfig.CreateMapper();
		services.AddSingleton(mapper);
		#endregion
	}
}
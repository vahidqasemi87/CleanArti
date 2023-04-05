
using Application.Common.Behavious;
using Application.Common.Mappings;
using Application.Features.Orders.Command.CreateOrder;
using AutoMapper;
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

		services.AddScoped<CalculateFinalPrice>();


		services.AddAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());
		#region [Config Automaspper]
		var mapperConfig =
			new MapperConfiguration(mc => mc.AddProfile(new MapperProfile()));
		IMapper mapper = mapperConfig.CreateMapper();
		services.AddSingleton(mapper);
		#endregion
	}
}
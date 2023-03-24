using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
	//IServiceCollection -> Microsoft.Extensions.DependencyInjection
	public static void AddApplication(this IServiceCollection services)
	{
		services.AddMediatR(assemblies: System.Reflection.Assembly.GetExecutingAssembly());
	}
}
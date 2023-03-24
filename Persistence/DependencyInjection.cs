using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence;

public static class DependencyInjection
{
	public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
		{
			options.UseSqlServer(connectionString: configuration.GetConnectionString(name: "Standard"),
				b=>
				b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
		});
		services.AddScoped<IApplicationDbContext>(p=>p.GetService<ApplicationDbContext>()!);
	}
}
using IdentityDemo.Command.UserAggregate;
using IdentityDemo.Contracts;
using IdentityDemo.Contracts.UserAggregate;
using IdentityDemo.Domain;
using IdentityDemo.Domain.UserAggregate;
using IdentityDemo.Infrastructurs.Context;
using IdentityDemo.Infrastructurs.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityDemo.Extensions;

public static class ConfigureServices
{
	public static IServiceCollection UseSql(this IServiceCollection services, IConfiguration configuration)
	{
		string conn = configuration.GetConnectionString("IdentityConnection");

		services.AddDbContext<IdentityServerDbContext>(option => option.UseSqlServer(conn));
		return services;
	}
	public static IServiceCollection AddScopeConfigure(this IServiceCollection services)
	{
		services.AddScoped<IUnitOfWord, UnitOfWork>();
		services.AddScoped<IRepository<User>, Repository<User>>();
		services.AddScoped<IUserServiceCommand, UserServiceCommand>();
		services.AddIdentity<User, Role>(option =>
		{
			option.Password.RequireNonAlphanumeric = false;
			option.Password.RequiredLength = 1;
			option.Password.RequireUppercase = false;
			option.Password.RequireLowercase = false;
			option.Password.RequireDigit = false;
			option.Password.RequiredUniqueChars = 1;
		}
		)
			.AddEntityFrameworkStores<IdentityServerDbContext>()
			.AddDefaultTokenProviders();
		return services;
	}
}
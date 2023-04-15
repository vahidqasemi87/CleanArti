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

		#region [Identity]




		builder.Services.AddDbContext<IdentityServerDbContext>(optionsAction: option =>
		{
			option.UseSqlServer(connectionString: builder.Configuration.GetConnectionString(name: "IdentityConnection"));
		});

		#endregion

		builder.Services.AddAuthentication();

		builder.Services.AddTransient<IUnitOfWord, UnitOfWork>();

		builder.Services.AddScoped<IUserServiceCommand, UserServiceCommand>();

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

		app.UseCors(configurePolicy: delegate (CorsPolicyBuilder builder)
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
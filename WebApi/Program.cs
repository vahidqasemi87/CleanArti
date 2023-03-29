
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Application;
using Persistence;
using Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MediatR;
using System.Reflection;
using WebApi.Infrastructure.AppSettings;

namespace WebApi;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);


		#region[Add Dependency injection]

		builder.Services.AddApplication();
		builder.Services.AddPersistence(configuration: builder.Configuration);

		#endregion \[Add Dependency injection]

		#region [DbContext]
		builder.Services.AddDbContext<ApplicationDbContext>(options =>
		{
			options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString(name: "Standard"));
		});
		#endregion

		#region [MediatR]
		builder.Services.AddMediatR(assemblies: System.Reflection.Assembly.GetExecutingAssembly());
		#endregion


		// Add services to the container.

		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		#region [Read from appsettings config]

		IConfigurationRoot? configuration =
			new ConfigurationBuilder()
			.AddJsonFile("appsettings.json").Build();

		builder.Services.Configure<AddressApi>(config: builder.Configuration.GetSection(key: "AddressApi"));
		#endregion

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();


		app.MapControllers();

		app.Run();
	}
}
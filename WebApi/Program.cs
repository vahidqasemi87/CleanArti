using Application;
using Application.Common.Interfaces.Learning02;
using Application.CRUD.Customers.Command.CreateCustomer;
using Application.Features.Customers.Command.CreateCustomer;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using Persistence.Context;
using Persistence.Customers;
using Persistence.Orders;
using Persistence.Products;
using Persistence.UOF;
using Serilog;
using System;
using WebApi.Infrastructure.AppSettings;
using WebApi.Infrastructure.Middlewares;

namespace WebApi;

public class Program
{
	public static void Main(string[] args)
	{
		WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

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

		#region[DI Scope]
		builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
		builder.Services.AddScoped<ICustomerRepository, CustomersRepository>();
		builder.Services.AddScoped<IOrderRepository, OrderRepository>();
		builder.Services.AddScoped<IProductRepository, ProductRepository>();

		//builder.Services.AddValidatorsFromAssemblyContaining<CustomerFluentValidation>();


		#endregion

		#region [MediatR]
		builder.Services.AddMediatR(options =>
		{
			options.RegisterServicesFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
		});
		#endregion

		#region [Generate root Path]
		var rootProject =
			builder.Environment.ContentRootPath;

		var fileName = $"{rootProject}\\LogFolder\\Log.txt";

		if (!System.IO.Directory.Exists($"{rootProject}\\LogFolder"))
			System.IO.Directory.CreateDirectory($"{rootProject}\\LogFolder");
		#endregion

		#region [Serilog Configuration]
		IConfigurationRoot configuration =
			new ConfigurationBuilder()
			.AddJsonFile("appsettings.json").Build();


		//روش اول از طریق 
		//appSettings -->

		//builder
		//	.Host
		//	.UseSerilog(configureLogger:
		//	(context, configuration) => configuration
		//	.ReadFrom
		//	.Configuration(configuration: context.Configuration));


		// روش دوم از طرق 
		// C# -->

		Log.Logger = new LoggerConfiguration()
			.ReadFrom.Configuration(configuration)
			.Enrich.FromLogContext()
			.WriteTo.Console()
			.WriteTo.Seq(serverUrl: "http://localhost:5341")
			.MinimumLevel.Override(source: "Microsoft", minimumLevel: Serilog.Events.LogEventLevel.Error)
			.WriteTo.File(path: fileName,
				restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error,
				rollingInterval: RollingInterval.Day,
					retainedFileCountLimit: null,
			fileSizeLimitBytes: null,
			shared: true,
			flushToDiskInterval: TimeSpan.FromSeconds(value: 1))
			//.MinimumLevel.Override(source: "Microsoft", minimumLevel: Serilog.Events.LogEventLevel.Error)
			//.MinimumLevel.Override(source: "RestSharp", minimumLevel: Serilog.Events.LogEventLevel.Error)
			//.MinimumLevel.Override(source: "RestClient", minimumLevel: Serilog.Events.LogEventLevel.Error)
			.CreateLogger();

		builder.Host.UseSerilog();
		#endregion


		// Add services to the container.
		builder.Services.AddControllers();

		builder.Services.AddEndpointsApiExplorer();

		builder.Services.AddSwaggerGen();

		#region [Read from appsettings config]
		builder.Services.Configure<AddressApi>(config: builder.Configuration.GetSection(key: "AddressApi"));
		#endregion

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseSerilogRequestLogging();

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.UseMiddleware<ErrorHandlingMiddleware>();

		app.Run();
	}
}
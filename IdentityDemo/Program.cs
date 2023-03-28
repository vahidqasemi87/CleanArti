

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
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();



		#region [Identity]
		//builder.Services.AddDbContext<JwtAuthContext>(optionsAction: option =>
		//{
		//	option.UseSqlServer(connectionString: builder.Configuration.GetConnectionString(name: "IdentityConnection"));
		//});

		
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
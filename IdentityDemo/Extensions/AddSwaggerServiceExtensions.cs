using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace IdentityDemo.Extensions;

public static class AddSwaggerServiceExtensions
{
	public static IServiceCollection AddSwaggerService(this IServiceCollection services,
															  IConfiguration configuration)
	{
		var oAuthOption = configuration.GetSection("OAuth").Get<OAuthOption>();
		var swaggerOption = configuration.GetSection("Swagger").Get<SwaggerOption>();

		if (swaggerOption != null && swaggerOption.Enabled == true)
		{
			services.AddSwaggerGen(delegate (SwaggerGenOptions c)
			{
				c.SwaggerDoc(swaggerOption.SwaggerDoc.Name, new OpenApiInfo
				{
					Title = swaggerOption.SwaggerDoc.Title,
					Version = swaggerOption.SwaggerDoc.Version
				});
				c.AddSecurityDefinition("Oauth2", new OpenApiSecurityScheme
				{
					Name = "Authorization",
					Description = "Oauth2",
					BearerFormat = "Bearer <token>",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.OAuth2,
					Flows = new OpenApiOAuthFlows
					{
						AuthorizationCode = new OpenApiOAuthFlow
						{
							AuthorizationUrl = new Uri($"{oAuthOption.Authority}/connect/authorize"),
							TokenUrl = new Uri($"{oAuthOption.Authority}/connect/token"),
							Scopes = oAuthOption.Scopes
						}
					},
				});
				c.OperationFilter<AddParamsToHeader>();

				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath, true);

			});
		}

		return services;
	}
}


public class AddParamsToHeader : IOperationFilter
{
	public void Apply(OpenApiOperation operation, OperationFilterContext context)
	{
		if (operation.Security == null)
			operation.Security = new List<OpenApiSecurityRequirement>();


		operation.Security.Add(new OpenApiSecurityRequirement()
		{
			{
				new OpenApiSecurityScheme()
				{
					Name="Oauth2",
					Scheme= "Oauth2",
					In = ParameterLocation.Header,
					Reference = new OpenApiReference()
					{
						Type= ReferenceType.SecurityScheme,
						Id= "Oauth2"
					}
				}, new List<string>()
			}
		});
	}
}

public class SwaggerOption
{
	public bool Enabled { get; set; } = true;
	public SwaggerDoc SwaggerDoc { get; set; }
}

public class SwaggerDoc
{
	public string Version { get; set; } = "v1";
	public string Title { get; set; } = string.Empty;
	public string Name { get; set; } = "v1";
	public string URL { get; set; } = "/swagger/v1/swagger.json";
}
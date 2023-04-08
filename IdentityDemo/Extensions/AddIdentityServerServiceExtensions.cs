using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace IdentityDemo.Extensions
{
	public static class AddIdentityServerServiceExtensions
	{
		public static IServiceCollection AddIdentityServerService(this IServiceCollection services, IConfiguration configuration)
		{
			var oAuthOption = configuration.GetSection("OAuth").Get<OAuthOption>();

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(o =>
			{
				o.Authority = oAuthOption.Authority;
				o.Audience = oAuthOption.Audience;
				o.RequireHttpsMetadata = oAuthOption.RequireHttpsMetadata;
				o.BackchannelHttpHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = delegate { return true; } };
				o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
				{
					ValidateAudience = oAuthOption.ValidateAudience,
					ValidateIssuer = oAuthOption.ValidateIssuer,
					ValidateIssuerSigningKey = oAuthOption.ValidateIssuerSigningKey
				};
			});

			return services;
		}
	}
}
public class OAuthOption
{
	public string Authority { get; set; } = string.Empty;
	public string Audience { get; set; } = string.Empty;
	public bool RequireHttpsMetadata { get; set; } = false;
	public Dictionary<string, string> Scopes { get; set; } = new Dictionary<string, string>();
	public bool ValidateAudience { get; set; } = false;
	public bool ValidateIssuer { get; set; } = false;
	public bool ValidateIssuerSigningKey { get; set; } = false;

}
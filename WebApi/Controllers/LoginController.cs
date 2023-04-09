using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;
using WebApi.Infrastructure.AppSettings;
using WebApi.ViewModels;

namespace WebApi.Controllers;

[Route(template: "api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
	private readonly AddressApi _addressApi;
	private readonly ILogger<LoginController> _logger;
	public LoginController(IOptions<AddressApi> addressApi, ILogger<LoginController> logger)
	{
		_addressApi = addressApi.Value;
		_logger = logger;
		_logger.LogInformation("Login Controller is called ... ");
	}

	[HttpPost(template: "Login")]
	public async Task<IActionResult> Login(UserLogin userLogin)
	{
		_logger.LogInformation("Login get method staeting ... ");
		try
		{
			var options = new RestClientOptions("https://localhost:7001")
			{
				MaxTimeout = -1,
			};
			var client = new RestClient(options);

			string requestUrl = _addressApi.RequestLogin!;
			var request = new RestRequest(requestUrl, Method.Post);



			request.AddHeader("Content-Type", "application/json");

			//var body = @$"username:{userLogin.Username},password:{userLogin.Password}";

			var body = JsonConvert.SerializeObject(userLogin);

			request.AddStringBody(body, DataFormat.Json);
			RestResponse response = await client.ExecuteAsync(request);
			Console.WriteLine(response.Content);
			if (response.IsSuccessful)
			{
				return Ok(response);
			}
			return BadRequest();
		}
		catch (Exception ex)
		{
			_logger.LogError(message: ex.Message);
			return BadRequest(ex.Message);
		}





	}
}
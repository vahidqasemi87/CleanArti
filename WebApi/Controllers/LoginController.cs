using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;
using WebApi.Infrastructure.AppSettings;
using WebApi.ViewModels;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
	private readonly AddressApi _addressApi;
	public LoginController(IOptions<AddressApi> addressApi)
	{
		_addressApi = addressApi.Value;
	}

	[HttpPost("Login")]
	public async Task<IActionResult> Login(UserLogin userLogin)
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
}
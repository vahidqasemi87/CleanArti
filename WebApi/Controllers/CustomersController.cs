using Application.Features.Commands.Customers.CreateCustomer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
	private readonly IMediator _mediator;
    public CustomersController(IMediator mediator)
    {
		_mediator = mediator;
    }
    [HttpPost]
	public async Task<IActionResult>  Get(string username,string password,string name,string family,string mobile,string address)
	{
		var rr = await _mediator.Send(new CreateCustomerCommand() 
		{
			Address = address,
			Family=family,
			Mobile= mobile,
			Name = name,
			Password = password,
			Username = username,
		});
		return Ok(rr);
	}
}

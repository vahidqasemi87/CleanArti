using Application.Features.Commands.Customers.CreateCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.ViewModels;

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
	public async Task<IActionResult> Get(CreateCustomerViewModel input)
	{
		var rr = await _mediator.Send(new CreateCustomerCommand()
		{
			Address =  input.Address,
			Family =   input.Family,
			Mobile =   input.Mobile,
			Name =     input.Name,
			Password = input.Password,
			Username = input.Username,
		});
		return Ok(rr);
	}
}

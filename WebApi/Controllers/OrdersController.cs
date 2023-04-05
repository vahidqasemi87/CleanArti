
using Application.Features.Orders.Command.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.ViewModels;

namespace WebApi.Controllers;

//
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
	private readonly IMediator _mediator;
	public OrdersController(IMediator mediator)
	{
		_mediator = mediator;
	}
	[HttpPost("CreateOrder")]
	public async Task<IActionResult> CreateOrder(CreateOrderViewModel input)
	{
		var validationCheck = ModelState.IsValid;

		if (!validationCheck)
		{
			return BadRequest();
		}


		var rr = await _mediator.Send(new CreateOrderCommand(customerId: input.CustomerId)
		{
			IsPayed = input.IsPayed,
			IsSend = input.IsSend,
			OrderDate = input.OrderDate,
			PaymentCode = input.PaymentCode,
			Price = input.Price,
			//CustomerId = input.CustomerId,
		});

		return Ok(value: rr);
	}
}

using Application.Features.Orders.Command.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebApi.ViewModels;

namespace WebApi.Controllers;

//
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
	private readonly IMediator _mediator;
	private ILogger<OrdersController> Logger { get; }
	public OrdersController(IMediator mediator, ILogger<OrdersController> logger)
	{
		_mediator = mediator;
		Logger = logger;
		Logger.LogInformation("Order Controller is called ... ");
	}
	[HttpPost("CreateOrder")]
	public async Task<IActionResult> CreateOrder(CreateOrderViewModel input)
	{
		try
		{
			Logger.LogInformation("Order get method staeting ... ");

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
		catch (System.Exception ex)
		{
			Logger.LogError(message: ex.Message);
			return BadRequest(ex.Message);
		}

	}
}
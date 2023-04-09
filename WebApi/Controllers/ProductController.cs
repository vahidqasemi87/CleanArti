
using Application.Features.Products.Command.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System.Threading.Tasks;
using WebApi.ViewModels;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
	private readonly IMediator _mediator;
	private readonly ILogger<ProductController> _logger;
	public ProductController(IMediator mediator, ILogger<ProductController> logger)
	{
		_mediator = mediator;
		_logger = logger;
	}
	[HttpPost("CreateProduct")]
	public async Task<IActionResult> Get(CreateProductViewModel input)
	{
		try
		{
			_logger.LogInformation("Product get method staeting ... ");

			var rr = await _mediator.Send(new CreateProductCommand()
			{
				Barcode = input.Barcode,
				Description = input.Barcode,
				Name = input.Name,
				Rate = input.Rate,
			});
			return Ok(rr);
		}
		catch (System.Exception ex)
		{
			_logger.LogError(message: ex.Message);
			return BadRequest(ex.Message);
		}
	}
}
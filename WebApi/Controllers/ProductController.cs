using Application.Features.Commands.Customers.CreateCustomer;
using Application.Features.Commands.Products.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.ViewModels;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
	private readonly IMediator _mediator;
	public ProductController(IMediator mediator)
	{
		_mediator = mediator;
	}
	[HttpPost("CreateProduct")]
	public async Task<IActionResult> Get(CreateProductViewModel input)
	{
		var rr = await _mediator.Send(new CreateProductCommand()
		{
			Barcode = input.Barcode,
			Description = input.Barcode,
			Name = input.Name,
			Rate = input.Rate,
		});
		return Ok(rr);
	}
}

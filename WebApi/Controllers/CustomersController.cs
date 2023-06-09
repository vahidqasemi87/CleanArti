﻿using Application.Features.Customers.Command.CreateCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebApi.ViewModels;

namespace WebApi.Controllers;

[Route(template: "api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
	private readonly IMediator _mediator;
	private readonly ILogger<CustomersController> _logger;


	public CustomersController(IMediator mediator, ILogger<CustomersController> logger)
	{
		_mediator = mediator;
		_logger = logger;
		_logger.LogInformation(message: "Customer Controller is called ... ");
	}
	[HttpPost]
	public async Task<IActionResult> Get(CreateCustomerViewModel input)
	{
		try
		{
			_logger.LogInformation(message: "Customer get method staeting ... ");
			if (!ModelState.IsValid)
				return BadRequest(error: "موارد منطبق نمی باشد");



			//throw new System.Exception("خطای ساختگی");

			var rr = await _mediator.Send(request: new CreateCustomerCommand()
			{
				Address = input.Address,
				Family = input.Family,
				Mobile = input.Mobile,
				Name = input.Name,
				Password = input.Password,
				Username = input.Username,
				NationalCode = input.NationalCode,
			});

			return Ok(value: rr);
		}
		catch (System.Exception ex)
		{
			_logger.LogError(message: ex.Message);
			return BadRequest(error: ex.Message);
		}
	}
}
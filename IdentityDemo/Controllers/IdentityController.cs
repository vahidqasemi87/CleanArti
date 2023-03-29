using IdentityDemo.Contracts.UserAggregate;
using IdentityDemo.Domain.UserAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IdentityController : ControllerBase
{
	private readonly IUserServiceCommand _userServiceCommand;

	public IdentityController(IUserServiceCommand userServiceCommand)
	{
		_userServiceCommand = userServiceCommand;
	}

	[HttpGet]
	public IActionResult Get()
	{
		return new JsonResult("Hello World!");
	}

	[HttpPost("CreateUser")]
	public async Task<IActionResult> CreateUser([FromBody] UserDto user)
	{
		await _userServiceCommand.Add(user);
		return Ok(user);
	}

	[HttpGet("UpdateSecurityStamp")]
	public async Task<IActionResult> UpdateSecurityStamp()
	{
		await _userServiceCommand.UpdateSecurityStamp();
		return Ok();
	}
	[HttpPost("UserLogin")]
	public async Task<IActionResult> LoginUser([FromBody] LoginDto user)
	{
		var findedUser = 
			await _userServiceCommand.Login(loginDto: user);
		if (user != null)
			return Ok();
		return BadRequest("نام کاربری و رمز عبور مطابقت ندارد");
	}
}

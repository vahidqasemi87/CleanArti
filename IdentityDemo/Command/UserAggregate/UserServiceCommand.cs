using IdentityDemo.Contracts;
using IdentityDemo.Contracts.UserAggregate;
using IdentityDemo.Domain.UserAggregate;
using Microsoft.AspNetCore.Identity;

namespace IdentityDemo.Command.UserAggregate;

public class UserServiceCommand : IUserServiceCommand
{
	private readonly UserManager<User> _userManager;
	private readonly IUnitOfWord _unitOfWord;


	public UserServiceCommand(UserManager<User> userManager, IUnitOfWord unitOfWord)
	{
		_userManager = userManager;
		_unitOfWord = unitOfWord;
	}


	public async Task<User> Add(UserDto user)
	{
		var newUser = new User 
		{
			UserName = user.UserName,
			FirstName=user.FirstName,
			LastName = user.LastName,
			CodeMelli = user.CodeMelli,
		};

		try
		{
			var aaa =
				await _userManager.CreateAsync(newUser,user.Password);
			_unitOfWord.SaveChangeAsync();
			return newUser;
		}
		catch (Exception ex)
		{
			//Log
		}
		return null;
	}

	public async Task UpdateSecurityStamp()
	{
		var user = await _userManager.FindByIdAsync("3");
		user!.SecurityStamp = Convert.ToString(Guid.NewGuid());
		_unitOfWord.SaveChangeAsync();
	}
}
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
			FirstName = user.FirstName,
			LastName = user.LastName,
			CodeMelli = user.CodeMelli,
		};

		try
		{
			var aaa =
				await _userManager.CreateAsync(newUser, user.Password);
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

	public async Task<User> Login(LoginDto loginDto)
	{
		var getInfo =
			await _userManager.FindByNameAsync(loginDto.UserName);

		if (getInfo == null)
		{
			return null;
		}

		//string passwordHash = Helpers.Security.Hashing.GetSha256(loginDto.Password);

		if(string.IsNullOrWhiteSpace(loginDto.Password))
		{
			return null;
		}

		string? masterPassword =
			getInfo.PasswordHash;//ApplicationSettings.MasterPassword;

		

		
		var validationPassword = 
			await _userManager.CheckPasswordAsync(getInfo,loginDto.Password);


		if (validationPassword == false) return null;

		//if (string.Compare(passwordHash,masterPassword,ignoreCase:true)!=0)
		//{
		//	return null;
		//}

		return getInfo;

	}
}
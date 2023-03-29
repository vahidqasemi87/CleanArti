using IdentityDemo.Domain.UserAggregate;

namespace IdentityDemo.Contracts.UserAggregate;

public interface IUserServiceCommand
{
	Task<User> Add(UserDto user);
	Task UpdateSecurityStamp();
	Task<User> Login(LoginDto loginDto);
}

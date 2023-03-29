namespace IdentityDemo.Domain.UserAggregate;

public class UserDto
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string CodeMelli { get; set; }
	public string Email { get; set; }
	public string UserName { get; set; }
	public string Password { get; set; }
}


public class LoginDto
{
	public string UserName { get; set; }
	public string Password { get; set; }
}
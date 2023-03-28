using Microsoft.AspNetCore.Identity;

namespace IdentityDemo.Domain.UserAggregate;

public class User : IdentityUser<long>
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string CodeMelli { get; set; }
	public override string? PhoneNumber { get; set; }
	public override string? Email { get; set; }
}

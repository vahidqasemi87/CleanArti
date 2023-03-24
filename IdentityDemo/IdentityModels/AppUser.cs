namespace IdentityDemo.IdentityModels;

public class AppUser : Microsoft.AspNetCore.Identity.IdentityUser
{
	public string? Name { get; set; }
}

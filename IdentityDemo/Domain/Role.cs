using Microsoft.AspNetCore.Identity;

namespace IdentityDemo.Domain;

public class Role : IdentityRole<long>
{
	public Role(string name) : base(name)
	{

	}
}

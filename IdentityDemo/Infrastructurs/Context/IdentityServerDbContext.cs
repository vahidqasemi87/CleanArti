using IdentityDemo.Domain;
using IdentityDemo.Domain.UserAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityDemo.Infrastructurs.Context;

public class IdentityServerDbContext : IdentityDbContext<User, Role, long>
{

	public IdentityServerDbContext(DbContextOptions<IdentityServerDbContext> options)
		: base(options)
	{

	}

	public new DbSet<User> Users { get; set; }
	public new DbSet<Role> Roles { get; set; }


}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityDemo.IdentityModels;

public class JwtAuthContext
	: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<AppUser>
{


	public JwtAuthContext(DbContextOptions<JwtAuthContext> options) : base(options)
	{

	}


	//public Microsoft.EntityFrameworkCore.DbSet<AppUser> Users { get; set; }


	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		//builder.Entity<IdentityUser>(c =>
		//{
		//	c.ToTable(name: "User");
		//});
		//builder.Entity<IdentityRole>(c =>
		//{
		//	c.ToTable(name: "Role");
		//});
		//builder.Entity<IdentityUserRole<string>>(c =>
		//{
		//	c.ToTable(name: "UserRoles");
		//});
		//builder.Entity<IdentityUserClaim<string>>(c =>
		//{
		//	c.ToTable(name: "UserClaims`002                                                                                                                                                      ");
		//});
		//builder.Entity<IdentityUserLogin<string>>(c =>
		//{
		//	c.ToTable(name: "UserLogins");
		//});
		//builder.Entity<IdentityRoleClaim<string>>(c =>
		//{
		//	c.ToTable(name: "RoleClaims");
		//});
		//builder.Entity<IdentityUserToken<string>>(c =>
		//{
		//	c.ToTable(name: "UserTokens");
		//});
	}
}
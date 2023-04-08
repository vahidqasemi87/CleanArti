using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence.Context;

public class ApplicationDbContextFactory :
	IDesignTimeDbContextFactory<ApplicationDbContext>
{
	public ApplicationDbContext CreateDbContext(string[] args)
	{
		var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
		builder.UseSqlServer("server=.;database=CleanDb;uid=sa;pwd=Ss12345!@#$%;TrustServerCertificate=true;");
		return new ApplicationDbContext(builder.Options);
	}
}

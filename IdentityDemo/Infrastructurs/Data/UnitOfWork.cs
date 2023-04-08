using IdentityDemo.Contracts;
using IdentityDemo.Infrastructurs.Context;

namespace IdentityDemo.Infrastructurs.Data;

public class UnitOfWork : IUnitOfWord
{
	private readonly IdentityServerDbContext _context;
	public UnitOfWork(IdentityServerDbContext context)
	{
		_context = context;
	}
	public void SaveChange()
	{
		_context.SaveChanges();
	}

	public void SaveChangeAsync()
	{
		_context.SaveChangesAsync();
	}
}

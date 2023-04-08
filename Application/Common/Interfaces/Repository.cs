namespace Application.Common.Interfaces;

//public class Repository<T> : IRepository<T> where T : class
//{
//	//private readonly IApplicationDbContext _context;
//	private readonly ContextDemo _context;
//	private readonly DbSet<T> Entity;

//    public Repository(ContextDemo context)
//    {
//		_context = context;
//		Entity = _context.Set<T>();

//    }
//    public async Task AddAsync(T entity)
//	{

//		Entity.Add(entity);
//		_context.SaveChanges();
//	}

//	public void Delete(T entity)
//	{
//		throw new NotImplementedException();
//	}
//}

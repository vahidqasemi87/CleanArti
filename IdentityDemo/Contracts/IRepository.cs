namespace IdentityDemo.Contracts;

public interface IRepository<T>
{
	void Add(T entity);
	void Delete(T entity);
}

using System.Threading.Tasks;

namespace Application.Common.Interfaces;

public interface IRepository<T>
{
	Task AddAsync(T entity);
	void Delete(T entity);
}

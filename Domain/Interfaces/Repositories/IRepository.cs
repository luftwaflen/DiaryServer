using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories;

public interface IRepository<T>
{
    Task<List<T>> GetAll();
    Task<List<T>> Get(Expression<Func<T, bool>> predicate);
    Task Create(T model);
    Task Update(T model);
    Task Delete(T model);
}
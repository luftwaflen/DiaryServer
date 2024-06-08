namespace Domain.Interfaces.Repositories;

public interface IRepository<T>
{
    Task<List<T>> GetAll();
    Task Create(T model);
    Task Update(T model);
    Task Delete(T model);
}
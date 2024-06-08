namespace Domain.Interfaces.Services;

public interface IService<T>
{
    Task<List<T>> GetAll();
    Task Create(T model);
    Task Update(T model);
    Task Delete(T model);
}
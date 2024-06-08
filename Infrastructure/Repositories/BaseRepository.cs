using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public abstract class BaseRepository<T> : IRepository<T> where T : class
{
    private readonly DiaryDbContext _db;

    public BaseRepository(DiaryDbContext db)
    {
        _db = db;
    }

    public async Task<List<T>> GetAll()
    {
        var models = await _db.Set<T>().ToListAsync();
        return models;
    }

    public async Task Create(T model)
    {
        await _db.Set<T>().AddAsync(model);
        await _db.SaveChangesAsync();
    }

    public async Task Update(T model)
    {
        _db.Set<T>().Update(model);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(T model)
    {
        _db.Set<T>().Remove(model);
        await _db.SaveChangesAsync();
    }
}
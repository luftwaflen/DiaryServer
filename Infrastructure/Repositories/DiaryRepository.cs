using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Infrastructure.Repositories;

public class DiaryRepository : BaseRepository<Diary>, IDiaryRepository
{
    public DiaryRepository(DiaryDbContext db) : base(db)
    {
    }
}
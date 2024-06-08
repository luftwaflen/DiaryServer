using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Infrastructure.Repositories;

public class DiaryNoteRepository : BaseRepository<DiaryNote>, IDiaryNoteRepository
{
    public DiaryNoteRepository(DiaryDbContext db) : base(db)
    {
    }
}
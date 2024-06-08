using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Infrastructure.Repositories;

public class FamilyRepository : BaseRepository<Family>, IFamilyRepository
{
    public FamilyRepository(DiaryDbContext db) : base(db)
    {
    }
}
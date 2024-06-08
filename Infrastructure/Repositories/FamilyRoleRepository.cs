using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Infrastructure.Repositories;

public class FamilyRoleRepository : BaseRepository<FamilyRole>, IFamilyRoleRepository
{
    public FamilyRoleRepository(DiaryDbContext db) : base(db)
    {
    }
}
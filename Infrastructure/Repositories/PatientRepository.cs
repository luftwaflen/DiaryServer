using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Infrastructure.Repositories;

public class PatientRepository : BaseRepository<Patient>, IPatientRepository
{
    public PatientRepository(DiaryDbContext db) : base(db)
    {
    }
}
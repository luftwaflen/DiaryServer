using System.Security.Principal;
using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IPatientService
{
    Task<List<Patient>> GetAllPatients();
    Task<Patient> GetPatientById(Guid patientId);
    Task<Patient> RegisterPatient(string login, string email, string password, string firstName, string secondName);
    Task UpdatePatient(string login, string email, string password, string firstName, string secondName);
    Task DeletePatient(Guid patientId);
    Task<List<DiaryNote>> GetDiary(Guid patientId);
    Task<List<DiaryNote>> AddDiaryNote(Guid patientId, string pressureSys, string pressureDia, string pulse, string description);
    Task<List<DiaryNote>> UpdateDiaryNote(Guid diaryNoteId, string pressureSys, string pressureDia, string pulse, string description);
    Task<List<DiaryNote>> DeleteDiaryNote(Guid diaryNoteId);
    Task<List<Recipe>> GetRecipes(Guid patientId);
    Task<Doctor> GetPersonalDoctor(Guid patientId);
    Task<Family> CreateFamily(Guid patientId);
    Task<Family> GetPatientFamily(Guid patientId);
    Task DeleteFamily(Guid familyId);
    Task InviteToFamily(Guid familyId, Guid patientId);
    Task RemoveFromFamily(Guid familyId, Guid patientId);
}
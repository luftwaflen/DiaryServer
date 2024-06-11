using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IDoctorService
{
    Task<List<Doctor>> GetAllDoctors();
    Task<Doctor> GetDoctorById(Guid doctorId);
    Task<Doctor> RegisterDoctor(string login, string email, string password, string firstName, string secondName);
    Task UpdateDoctor(string login, string email, string password, string firstName, string secondName);
    Task DeleteDoctor(Guid doctorId);
    Task<List<Patient>> GetDoctorPatients(Guid doctorId);
    Task<List<Patient>> GetPatientsWithoutDoctor();
    Task AppendPatient(Guid doctorId, Guid patientId);
    Task RemovePatient(Guid doctorId, Guid patientId);
    Task CreateRecipe(Guid doctorId, Guid patientId, string recipeText);
    Task UpdateRecipe(Guid recipeId, string recipeText);
    Task DeleteRecipe(Guid recipeId);
}
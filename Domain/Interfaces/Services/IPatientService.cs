using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IPatientService
{
    Task<List<Patient>> GetAllPatients();
    Task<Patient> RegisterPatient(string login, string email, string password, string firstName, string secondName);
    Task UpdatePatient(string login, string email, string password, string firstName, string secondName);
    Task DeletePatient(string patientId);
}
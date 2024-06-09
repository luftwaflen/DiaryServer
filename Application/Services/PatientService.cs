using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }
    
    public Task<List<Patient>> GetAllPatients()
    {
        throw new NotImplementedException();
    }

    public Task<Patient> RegisterPatient(string login, string email, string password, string firstName, string secondName)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePatient(string login, string email, string password, string firstName, string secondName)
    {
        throw new NotImplementedException();
    }

    public Task DeletePatient(string patientId)
    {
        throw new NotImplementedException();
    }
}
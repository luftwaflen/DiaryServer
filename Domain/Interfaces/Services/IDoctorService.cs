using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IDoctorService
{
    Task<List<Doctor>> GetAllDoctors();
    Task<Doctor> RegisterDoctor(string login, string email, string password, string firstName, string secondName);
    Task UpdateDoctor(string login, string email, string password, string firstName, string secondName);
    Task DeleteDoctor(string doctorId);
}
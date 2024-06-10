using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IAdminService
{
    Task AddUserRole(string userRole);
    Task AddFamilyRole(string familyRole);
    Task<List<User>> GetAllUsers();
    Task<List<Admin>> GetAllAdmins();
    Task<List<Doctor>> GetAllDoctors();
    Task<List<Patient>> GetAllPatients();
    Task<Admin> RegisterAdmin(string login, string email, string password);
    Task UpdateAdmin(string login, string email, string password);
    Task DeleteAdmin(Guid adminId);
}
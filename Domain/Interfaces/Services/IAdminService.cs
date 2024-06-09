using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IAdminService
{
    Task AddUserRole(string userRole);
    Task AddFamilyRole(string familyRole);
    Task<List<Admin>> GetAllAdmins();
    Task<Admin> RegisterAdmin(string login, string email, string password);
    Task UpdateAdmin(string login, string email, string password);
    Task DeleteAdmin(string adminId);
}
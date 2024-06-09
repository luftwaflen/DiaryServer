using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IFamilyRoleRepository _familyRoleRepository;

    public AdminService(IAdminRepository adminRepository, IDoctorRepository doctorRepository, IPatientRepository patientRepository, IUserRoleRepository userRoleRepository, IFamilyRoleRepository familyRoleRepository)
    {
        _adminRepository = adminRepository;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
        _userRoleRepository = userRoleRepository;
        _familyRoleRepository = familyRoleRepository;
    }

    public async Task AddUserRole(string userRole)
    {
        var role = new UserRole(userRole);
        await _userRoleRepository.Create(role);
    }

    public async Task AddFamilyRole(string familyRole)
    {
        var role = new FamilyRole(familyRole);
        await _familyRoleRepository.Create(role);
    }

    public async Task<List<Admin>> GetAllAdmins()
    {
        var admins = await _adminRepository.GetAll();
        return admins;
    }

    public async Task<Admin> RegisterAdmin(string login, string email, string password)
    {
        var userRoles = await _userRoleRepository.Get(r => r.Role == "admin");
        var admin = new Admin(login, email, password, userRoles.First());
        await _adminRepository.Create(admin);
        return admin;
    }

    public async Task UpdateAdmin(string login, string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAdmin(string adminId)
    {
        throw new NotImplementedException();
    }
}
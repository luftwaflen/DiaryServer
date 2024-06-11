using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

public class AdminService : IAdminService
{
    private readonly IUserRepository _userRepository;
    private readonly IAdminRepository _adminRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IFamilyRoleRepository _familyRoleRepository;

    public AdminService(IUserRepository userRepository,
        IAdminRepository adminRepository,
        IDoctorRepository doctorRepository,
        IPatientRepository patientRepository,
        IUserRoleRepository userRoleRepository,
        IFamilyRoleRepository familyRoleRepository)
    {
        _userRepository = userRepository;
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

    public async Task<List<User>> GetAllUsers()
    {
        var users = await _userRepository.GetAll();
        return users;
    }

    public async Task<List<Admin>> GetAllAdmins()
    {
        var admins = await _adminRepository.GetAll();
        return admins;
    }

    public async Task<List<Doctor>> GetAllDoctors()
    {
        var doctors = await _doctorRepository.GetAll();
        return doctors;
    }

    public async Task<List<Patient>> GetAllPatients()
    {
        var patients = await _patientRepository.GetAll();
        return patients;
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
        var admins  =await _adminRepository.Get(a => a.Login == login);
        admins.First().Email = email;
        admins.First().Password = password;
        await _adminRepository.Update(admins.First());
    }

    public async Task DeleteUser(Guid userId)
    {
        var users = await _userRepository.Get(a => a.Id == userId);
        await _userRepository.Delete(users.First());
    }
}
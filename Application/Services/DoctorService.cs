using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IUserRoleRepository _userRoleRepository;

    public DoctorService(IDoctorRepository dsDoctorRepository, IUserRoleRepository userRoleRepository)
    {
        _doctorRepository = dsDoctorRepository;
        _userRoleRepository = userRoleRepository;
    }

    public async Task<List<Doctor>> GetAllDoctors()
    {
        var doctors = await _doctorRepository.GetAll();
        return doctors;
    }

    public async Task<Doctor> RegisterDoctor(string login, string email, string password, string firstName, string secondName)
    {
        var roles = await _userRoleRepository.Get(r => r.Role == "doctor");
        var doctor = new Doctor(login, email, password, roles.First(), firstName, secondName);
        await _doctorRepository.Create(doctor);
        return doctor;
    }

    public async Task UpdateDoctor(string login, string email, string password, string firstName, string secondName)
    {
        var doctors = await _doctorRepository.Get(d => d.Login == login);
        doctors.First().Email = email;
        doctors.First().Password = password;
        doctors.First().FirstName = firstName;
        doctors.First().SecondName = secondName;
        await _doctorRepository.Update(doctors.First());
    }

    public async Task DeleteDoctor(string doctorId)
    {
        var doctors = await _doctorRepository.Get(d => d.Id == Guid.Parse(doctorId));
        await _doctorRepository.Delete(doctors.First());
    }
}
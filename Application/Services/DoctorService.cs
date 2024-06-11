using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUserRoleRepository _userRoleRepository;

    public DoctorService(IDoctorRepository dsDoctorRepository, IUserRoleRepository userRoleRepository, IPatientRepository patientRepository, IRecipeRepository recipeRepository)
    {
        _doctorRepository = dsDoctorRepository;
        _userRoleRepository = userRoleRepository;
        _patientRepository = patientRepository;
        _recipeRepository = recipeRepository;
    }

    public async Task<List<Doctor>> GetAllDoctors()
    {
        var doctors = await _doctorRepository.GetAll();
        return doctors;
    }

    public async Task<Doctor> GetDoctorById(Guid doctorId)
    {
        var doctors = await _doctorRepository.Get(d => d.Id == doctorId);
        return doctors.First();
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

    public async Task DeleteDoctor(Guid doctorId)
    {
        var doctors = await _doctorRepository.Get(d => d.Id == doctorId);
        await _doctorRepository.Delete(doctors.First());
    }

    public async Task<List<Patient>> GetDoctorPatients(Guid doctorId)
    {
        var doctors = await _doctorRepository.Get(d => d.Id == doctorId);
        return doctors.First().Patients;
    }

    public async Task AppendPatient(Guid doctorId, Guid patientId)
    {
        var doctors = await _doctorRepository.Get(d => d.Id == doctorId);
        var doctor = doctors.FirstOrDefault();
        var patients = await _patientRepository.Get(p => p.Id == patientId);
        var patient = patients.FirstOrDefault();
        doctor.Patients.Add(patient);
        patient.PersonalDoctor = doctor;
        await _doctorRepository.Update(doctor);
        await _patientRepository.Update(patient);
    }

    public async Task RemovePatient(Guid doctorId, Guid patientId)
    {
        var doctors = await _doctorRepository.Get(d => d.Id == doctorId);
        var doctor = doctors.FirstOrDefault();
        var patients = await _patientRepository.Get(p => p.Id == patientId);
        var patient = patients.FirstOrDefault();
        patient.PersonalDoctor = null;
        doctor.Patients.Remove(patient);
        await _doctorRepository.Update(doctor);
        await _patientRepository.Update(patient);
    }

    public async Task CreateRecipe(Guid doctorId, Guid patientId, string recipeText)
    {
        var doctors = await _doctorRepository.Get(d => d.Id == doctorId);
        var doctor = doctors.FirstOrDefault();
        var patients = await _patientRepository.Get(p => p.Id == patientId);
        var patient = patients.FirstOrDefault();
        var recipe = new Recipe(recipeText, patient, doctor);
        doctor.Recipes.Add(recipe);
        patient.Recipes.Add(recipe);
        await _recipeRepository.Create(recipe);
        await _patientRepository.Update(patient);
        await _doctorRepository.Update(doctor);
    }

    public async Task UpdateRecipe(Guid recipeId, string recipeText)
    {
        var recipes = await _recipeRepository.Get(r => r.Id == recipeId);
        var recipe = recipes.FirstOrDefault();
        recipe.Text = recipeText;
        await _recipeRepository.Update(recipe);
    }

    public async Task DeleteRecipe(Guid recipeId)
    {
        var recipes = await _recipeRepository.Get(r => r.Id == recipeId);
        var recipe = recipes.FirstOrDefault();
        await _recipeRepository.Delete(recipe);
    }
}
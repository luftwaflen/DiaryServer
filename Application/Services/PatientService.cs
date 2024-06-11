using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IDiaryNoteRepository _diaryNoteRepository;
    private readonly IFamilyRepository _familyRepository;
    private readonly IFamilyRoleRepository _familyRoleRepository;

    public PatientService(IPatientRepository patientRepository, IUserRoleRepository userRoleRepository, IDiaryNoteRepository diaryNoteRepository, IFamilyRepository familyRepository, IFamilyRoleRepository familyRoleRepository)
    {
        _patientRepository = patientRepository;
        _userRoleRepository = userRoleRepository;
        _diaryNoteRepository = diaryNoteRepository;
        _familyRepository = familyRepository;
        _familyRoleRepository = familyRoleRepository;
    }
    
    public async Task<List<Patient>> GetAllPatients()
    {
        var patients = await _patientRepository.GetAll();
        return patients;
    }

    public async Task<Patient> GetPatientById(Guid patientId)
    {
        var patients = await _patientRepository.Get(p => p.Id == patientId);
        return patients.First();
    }

    public async Task<Patient> RegisterPatient(string login, string email, string password, string firstName, string secondName)
    {
        var roles = await _userRoleRepository.Get(r => r.Role == "patient");
        var patient = new Patient(login, email, password, roles.First(), firstName, secondName);
        await _patientRepository.Create(patient);
        return patient;
    }

    public async Task UpdatePatient(string login, string email, string password, string firstName, string secondName)
    {
        var patients = await _patientRepository.Get(p => p.Login == login);
        var patient = patients.FirstOrDefault();
        patient.Email = email;
        patient.Password = password;
        patient.FirstName = firstName;
        patient.SecondName = secondName;
        await _patientRepository.Update(patient);
    }

    public async Task DeletePatient(Guid patientId)
    {
        var patients = await _patientRepository.Get(p => p.Id == patientId);
        await _patientRepository.Delete(patients.First());
    }

    public async Task<List<DiaryNote>> GetDiary(Guid patientId)
    {
        var patients = await _patientRepository.Get(p => p.Id == patientId);
        var patient = patients.First();
        return patient.Diary.DiaryNotes;
    }

    public async Task<List<DiaryNote>> AddDiaryNote(Guid patientId, string pressureSys, string pressureDia, string pulse, string description)
    {
        var patients = await _patientRepository.Get(p => p.Id == patientId);
        var patient = patients.First();
        var diaryNote = new DiaryNote(pressureSys, pressureDia, pulse, description);
        patient.Diary.DiaryNotes.Add(diaryNote);
        await _diaryNoteRepository.Create(diaryNote);
        await _patientRepository.Update(patient);
        return patient.Diary.DiaryNotes;
    }

    public async Task<DiaryNote> UpdateDiaryNote(Guid diaryNoteId, string pressureSys, string pressureDia, string pulse, string description)
    {
        var diaryNotes = await _diaryNoteRepository.Get(dn => dn.Id == diaryNoteId);
        var diaryNote = diaryNotes.First();
        diaryNote.PressureSys = pressureSys;
        diaryNote.PressureDia = pressureDia;
        diaryNote.Pulse = pulse;
        diaryNote.Description = description;
        await _diaryNoteRepository.Update(diaryNote);
        return diaryNote;
    }

    public async Task DeleteDiaryNote(Guid diaryNoteId)
    {
        var diaryNotes = await _diaryNoteRepository.Get(dn => dn.Id == diaryNoteId);
        var diaryNote = diaryNotes.First();
        await _diaryNoteRepository.Delete(diaryNote);
    }

    public async Task<List<Recipe>> GetRecipes(Guid patientId)
    {
        var patients = await _patientRepository.Get(p => p.Id == patientId);
        var patient = patients.First();
        return patient.Recipes;
    }

    public async Task<Doctor> GetPersonalDoctor(Guid patientId)
    {
        var patients = await _patientRepository.Get(p => p.Id == patientId);
        var patient = patients.First();
        return patient.PersonalDoctor;
    }

    public async Task<Family> CreateFamily(Guid patientId)
    {
        var patients = await _patientRepository.Get(p => p.Id == patientId);
        var patient = patients.First();
        var familyRoles = await _familyRoleRepository.Get(fr => fr.Role == "creator");
        var familyRole = familyRoles.FirstOrDefault();
        var family = new Family();
        patient.Family = family;
        patient.FamilyRole = familyRole;
        family.FamilyMembers.Add(patient);
        await _familyRepository.Create(family);
        await _patientRepository.Update(patient);

        return family;
    }

    public async Task<Family> GetPatientFamily(Guid patientId)
    {
        var patients = await _patientRepository.Get(p => p.Id == patientId);
        var patient = patients.First();
        return patient.Family;
    }

    public async Task DeleteFamily(Guid familyId)
    {
        var families = await _familyRepository.Get(f => f.Id == familyId);
        var family = families.FirstOrDefault();
        await _familyRepository.Delete(family);
    }

    public async Task InviteToFamily(Guid familyId, Guid patientId)
    {
        var families = await _familyRepository.Get(f => f.Id == familyId);
        var family = families.FirstOrDefault();
        var roles = await _familyRoleRepository.Get(fr => fr.Role == "member");
        var familyRole = roles.FirstOrDefault();
        var patients = await _patientRepository.Get(p => p.Id == patientId);
        var patient = patients.First();
        patient.Family = family;
        patient.FamilyRole = familyRole;
        family.FamilyMembers.Add(patient);
        await _patientRepository.Update(patient);
        await _familyRepository.Update(family);
    }

    public async Task RemoveFromFamily(Guid familyId, Guid patientId)
    {
        var families = await _familyRepository.Get(f => f.Id == familyId);
        var family = families.FirstOrDefault();
        var patients = await _patientRepository.Get(p => p.Id == patientId);
        var patient = patients.First();
        patient.Family = null;
        patient.FamilyRole = null;
        family.FamilyMembers.Remove(patient);
        await _patientRepository.Update(patient);
        await _familyRepository.Update(family);
    }
}
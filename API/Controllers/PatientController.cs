using API.Requests;
using API.Responses;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/Api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterPatientRequest request)
        {
            var patient = await _patientService.RegisterPatient(request.Login, request.Email, request.Password, request.FirstName, request.SecondName);
            var jwt = await JwtProvider.GetJwt(patient.Id, patient.UserRole.Role);
            var token = new JwtToken(jwt);
            return Ok(token);
        }

        [HttpGet("GetPatient")]
        public async Task<IActionResult> GetPatient(string patientId)
        {
            var patient = await _patientService.GetPatientById(Guid.Parse(patientId));
            return Ok(new PatientResponse(patient));
        }

        [HttpPost("AddDiaryNote")]
        public async Task<IActionResult> AddDiaryNote(AddDiaryNoteRequest request)
        {
            var notes = await _patientService.AddDiaryNote(Guid.Parse(request.PatientId), request.PressureSys, request.PressureDia, request.Pulse, request.Description);
            var response = new List<DiaryNoteResponse>();
            foreach (var note in notes)
            {
                response.Add(new DiaryNoteResponse(note));
            }
            return Ok(response);
        }

        [HttpPost("UpdateDiaryNote")]
        public async Task<IActionResult> UpdateDiaryNote(UpdateDiaryNoteRequest request)
        {
            var diaryNote = await _patientService.UpdateDiaryNote(Guid.Parse(request.NoteId), request.PressureSys, request.PressureDia, request.Pulse, request.Description);
            return Ok(new DiaryNoteResponse(diaryNote));
        }

        [HttpPost("DeleteDiaryNote")]
        public async Task<IActionResult> DeleteDiaryNote(string diaryNoteId)
        {
            await _patientService.DeleteDiaryNote(Guid.Parse(diaryNoteId));
            return Ok();
        }

        [HttpGet("GetDiary")]
        public async Task<IActionResult> GetDiary(string patientId)
        {
            var notes = await _patientService.GetDiary(Guid.Parse(patientId));
            var response = new List<DiaryNoteResponse>();
            foreach (var note in notes)
            {
                response.Add(new DiaryNoteResponse(note));
            }
            return Ok(response);
        }

        [HttpGet("GetRecipes")]
        public async Task<IActionResult> GetRecipes(string patientId)
        {
            var recipes = await _patientService.GetRecipes(Guid.Parse(patientId));
            var response = new List<RecipeResponse>();
            foreach (var recipe in recipes)
            {
                response.Add(new RecipeResponse(recipe));
            }
            return Ok(response);
        }

        [HttpGet("GetPersonalDoctor")]
        public async Task<IActionResult> GetPersonalDoctor(string patientId)
        {
            var doctor = await _patientService.GetPersonalDoctor(Guid.Parse(patientId));
            return Ok(new DoctorResponse(doctor));
        }

        [HttpPost("CreateFamily")]
        public async Task<IActionResult> CreateFamily(string patientId)
        {
            var family = await _patientService.CreateFamily(Guid.Parse(patientId));
            return Ok(new FamilyResponse(family));
        }

        [HttpGet("GetFamily")]
        public async Task<IActionResult> GetFamily(string patientId)
        {
            var family = await _patientService.GetPatientFamily(Guid.Parse(patientId));
            return Ok(new FamilyResponse(family));
        }

        [HttpGet("GetPatientsWithoutFamily")]
        public async Task<IActionResult> GetPatientsWithoutFamily()
        {
            var patients = await _patientService.GetPatientsWithoutFamily();
            var response = new List<PatientResponse>();
            foreach (var patient in patients)
            {
                response.Add(new PatientResponse(patient));
            }
            return Ok(response);
        }

        [HttpPost("DeleteFamily")]
        public async Task<IActionResult> DeleteFamily(string familyId)
        {
            await _patientService.DeleteFamily(Guid.Parse(familyId));
            return Ok();
        }

        [HttpPost("InviteToFamily")]
        public async Task<IActionResult> InviteToFamily(FamilyMemberOperation request)
        {
            await _patientService.InviteToFamily(Guid.Parse(request.FamilyId), Guid.Parse(request.PatientId));
            return Ok();
        }

        [HttpPost("RemoveFromFamily")]
        public async Task<IActionResult> RemoveFromFamily(FamilyMemberOperation request)
        {
            await _patientService.RemoveFromFamily(Guid.Parse(request.FamilyId), Guid.Parse(request.PatientId));
            return Ok();
        }
    }
}

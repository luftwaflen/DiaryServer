using API.Requests;
using API.Responses;
using Azure;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/Api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("GetDoctor")]
        public async Task<IActionResult> GetDoctor(string doctorId)
        {
            var doctor = await _doctorService.GetDoctorById(Guid.Parse(doctorId));
            return Ok(new DoctorResponse(doctor));
        }

        [HttpGet("GetDoctorPatients")]
        public async Task<IActionResult> GetDoctorPatients(string doctorId)
        {
            var patients = await _doctorService.GetDoctorPatients(Guid.Parse(doctorId));
            var response = new List<PatientResponse>();
            foreach (var patient in patients)
            {
                response.Add(new PatientResponse(patient));
            }
            return Ok(response);
        }

        [HttpPost("AppendPatient")]
        public async Task<IActionResult> AppendPatient(DoctorPatientOperation request)
        {
            await _doctorService.AppendPatient(Guid.Parse(request.DoctorId), Guid.Parse(request.PatientId));
            return Ok();
        }

        [HttpPost("RemovePatient")]
        public async Task<IActionResult> RemovePatient(DoctorPatientOperation request)
        {
            await _doctorService.RemovePatient(Guid.Parse(request.DoctorId), Guid.Parse(request.PatientId));
            return Ok();
        }

        [HttpPost("CreateRecipe")]
        public async Task<IActionResult> CreateRecipe(CreateRecipeRequest request)
        {
            await _doctorService.CreateRecipe(Guid.Parse(request.DoctorId), Guid.Parse(request.PatientId), request.Text);
            return Ok();
        }

        [HttpPost("UpdateRecipe")]
        public async Task<IActionResult> UpdateRecipe(UpdateRecipeRequest request)
        {
            await _doctorService.UpdateRecipe(Guid.Parse(request.RecipeId), request.Text);
            return Ok();
        }

        [HttpPost("DeleteRecipe")]
        public async Task<IActionResult> DeleteRecipe(string recipeId)
        {
            await _doctorService.DeleteRecipe(Guid.Parse(recipeId));
            return Ok();
        }
    }
}

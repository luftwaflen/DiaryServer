using API.Requests;
using API.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/Api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IUserService _userService;

        public AdminController(IAdminService adminService, IDoctorService doctorService, IPatientService patientService, IUserService userService)
        {
            _adminService = adminService;
            _doctorService = doctorService;
            _patientService = patientService;
            _userService = userService;
        }

        [HttpPost("AddUserRole")]
        public async Task<IActionResult> AddUserRole(AddUserRoleRequest request)
        {
            await _adminService.AddUserRole(request.UserRole);
            return Ok();
        }

        [HttpPost("AddFamilyRole")]
        public async Task<IActionResult> AddFamilyRole(AddFamilyRole request)
        {
            await _adminService.AddFamilyRole(request.FamilyRole);
            return Ok();
        }

        [HttpPost("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin(RegisterAdminRequest request)
        {
            var admin = await _adminService.RegisterAdmin(request.Login, request.Email, request.Password);
            return Ok(new AdminResponse(admin));
        }

        [HttpPost("RegisterDoctor")]
        public async Task<IActionResult> RegisterDoctor(RegisterDoctorRequest request)
        {
            var doctor = await _doctorService.RegisterDoctor(request.Login, request.Email, request.Password,
                request.FirstName, request.SecondName);

            return Ok(new DoctorResponse(doctor));
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _adminService.GetAllUsers();
            var response = new List<UserResponse>();
            foreach (var user in users)
            {
                response.Add(new UserResponse(user));
            }

            return Ok(response);
        }

        [HttpGet("GetAllAdmins")]
        public async Task<IActionResult> GetAllAdmins()
        {
            var admins = await _adminService.GetAllAdmins();
            var response = new List<AdminResponse>();
            foreach (var admin in admins)
            {
                response.Add(new AdminResponse(admin));
            }

            return Ok(response);
        }

        [HttpGet("GetAllDoctors")]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllDoctors();
            var response = new List<DoctorResponse>();
            foreach (var doctor in doctors)
            {
                response.Add(new DoctorResponse(doctor));
            }

            return Ok(response);
        }

        [HttpGet("GetAllPatients")]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatients();
            var response = new List<PatientResponse>();
            foreach (var patient in patients)
            {
                response.Add(new PatientResponse(patient));
            }

            return Ok(response);
        }

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            await _adminService.DeleteUser(Guid.Parse(userId));
            return Ok();
        }
    }
}

using Domain.Models;

namespace API.Responses;

public class DoctorResponse
{
    public DoctorResponse(Doctor doctor)
    {
        Id = doctor.Id;
        Login = doctor.Login;
        Email = doctor.Email;
        FirstName = doctor.FirstName;
        SecondName = doctor.SecondName;
    }

    public Guid Id { get; set; }
    public string Login { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Email { get; set; }
}
using Domain.Models;

namespace API.Responses;

public class PatientResponse
{
    public PatientResponse(Patient patient)
    {
        Id = patient.Id;
        Login = patient.Login;
        FirstName = patient.FirstName;
        SecondName = patient.SecondName;
        Email = patient.Email;
    }
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Email { get; set; }
}
namespace API.Requests;

public class RegisterPatientRequest
{
    public string Login { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
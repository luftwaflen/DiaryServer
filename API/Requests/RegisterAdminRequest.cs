using Domain.Models;

namespace API.Requests;

public class RegisterAdminRequest
{
    public string Login { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
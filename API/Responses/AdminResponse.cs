using Domain.Models;

namespace API.Responses;

public class AdminResponse
{
    public AdminResponse(Admin admin)
    {
        Id = admin.Id;
        Login = admin.Login;
        Email = admin.Email;
    }

    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
}
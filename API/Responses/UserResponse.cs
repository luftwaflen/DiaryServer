using Domain.Models;

namespace API.Responses;

public class UserResponse
{
    public UserResponse(User user)
    {
        Id = user.Id;
        Login = user.Login;
        Email = user.Email;
        UserRole = user.UserRole.Role;
    }

    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string UserRole { get; set; }
}
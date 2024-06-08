namespace Domain.Models;

public class UserRole
{
    public UserRole(string role)
    {
        Id = Guid.NewGuid();
        Role = role;
    }

    public Guid Id { get; set; }
    public string Role { get; set; }
}
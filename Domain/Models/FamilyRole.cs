namespace Domain.Models;

public class FamilyRole
{
    public FamilyRole(string role)
    {
        Id = Guid.NewGuid();
        Role = role;
    }

    public Guid Id { get; set; }
    public string Role { get; set; }
}
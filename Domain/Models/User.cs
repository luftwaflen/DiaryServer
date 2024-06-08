namespace Domain.Models;

public class User
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public virtual UserRole UserRole { get; set; }
    public virtual Family? Family { get; set; }
    public virtual FamilyRole? FamilyRole { get; set; }
}
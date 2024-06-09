namespace Domain.Models;

public class User
{
    public User(string login, string email, string password)
    {
        Id = Guid.NewGuid();
        Login = login;
        Email = email;
        Password = password;
    }
    public User(string login, string email, string password, UserRole userRole) : this(login, email, password)
    {
        UserRole = userRole;
    }

    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public virtual UserRole UserRole { get; set; }
    public virtual Family? Family { get; set; }
    public virtual FamilyRole? FamilyRole { get; set; }
}
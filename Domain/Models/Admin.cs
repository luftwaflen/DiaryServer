namespace Domain.Models;

public class Admin : User
{
    public Admin(string login, string email, string password) : base(login, email, password)
    {
        
    }
    public Admin(string login, string email, string password, UserRole userRole) : this(login, email, password)
    {
        UserRole = userRole;
    }
}
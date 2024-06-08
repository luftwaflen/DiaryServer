namespace Domain.Models;

public class Doctor : User
{
    public Doctor(string login, string email, string password, UserRole userRole) : base(login, email, password, userRole)
    {
        Patients = new List<Patient>();
        Recipes = new List<Recipe>();
    }

    public virtual List<Patient>? Patients { get; set; }
    public virtual List<Recipe>? Recipes { get; set; }
}
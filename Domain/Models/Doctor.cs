namespace Domain.Models;

public class Doctor : User
{
    public Doctor(string login, string email, string password, string firstName, string secondName) : base(login, email, password)
    {
        FirstName = firstName;
        SecondName = secondName;
        Patients = new List<Patient>();
        Recipes = new List<Recipe>();
    }
    public Doctor(string login, string email, string password, UserRole userRole, string firstName, string secondName) 
        : this(login, email, password, firstName, secondName)
    {
        UserRole = userRole;
    }

    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public virtual List<Patient>? Patients { get; set; }
    public virtual List<Recipe>? Recipes { get; set; }
}
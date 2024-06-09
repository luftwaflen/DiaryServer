namespace Domain.Models;

public class Patient : User
{
    public Patient(string login, string email, string password, string firstName, string secondName) : base(login, email, password)
    {
        FirstName = firstName;
        SecondName = secondName;
        Diary = new Diary();
        Recipes = new List<Recipe>();
    }
    public Patient(string login, string email, string password, UserRole userRole, string firstName, string secondName)
        : this(login, email, password, firstName, secondName)
    {
        UserRole = userRole;
    }

    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public virtual Diary Diary { get; set; }
    public virtual List<Recipe>? Recipes { get; set; }
}
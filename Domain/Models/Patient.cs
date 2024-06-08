namespace Domain.Models;

public class Patient : User
{
    public Patient(string login, string email, string password, UserRole userRole) : base(login, email, password, userRole)
    {
        Diary = new Diary();
        Recipes = new List<Recipe>();
    }

    public virtual Diary Diary { get; set; }
    public virtual List<Recipe>? Recipes { get; set; }
}
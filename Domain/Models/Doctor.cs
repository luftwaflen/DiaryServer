namespace Domain.Models;

public class Doctor : User
{
    public virtual List<Patient>? Patients { get; set; }
    public virtual List<Recipe>? Recipes { get; set; }
}
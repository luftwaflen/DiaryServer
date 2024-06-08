namespace Domain.Models;

public class Patient : User
{
    public virtual Diary Diary { get; set; }
}
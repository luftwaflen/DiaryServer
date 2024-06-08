namespace Domain.Models;

public class Family
{
    public Guid Id { get; set; }
    public virtual List<User> FamilyMembers { get; set; }
}
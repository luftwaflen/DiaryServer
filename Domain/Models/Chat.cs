namespace Domain.Models;

public class Chat
{
    public Chat(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        ChatMembers = new List<User>();
        Messages = new List<Message>();
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual List<User> ChatMembers { get; set; }
    public virtual List<Message> Messages { get; set; }
}
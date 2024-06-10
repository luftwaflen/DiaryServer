namespace Domain.Models;

public class Message
{
    public Message(string text)
    {
        Id = Guid.NewGuid();
        Text = text;
        Time = DateTime.Now;
    }

    public Message(string text, User sender) : this(text)
    {
        Sender = sender;
    }

    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime Time { get; set; }
    public virtual User Sender { get; set; }
}
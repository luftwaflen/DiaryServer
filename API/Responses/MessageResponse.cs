using Domain.Models;

namespace API.Responses;

public class MessageResponse
{
    public MessageResponse(Message message)
    {
        Id = message.Id;
        Text = message.Text;
        Time = message.Time;
        SenderId = message.Sender.Id;
    }

    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime Time { get; set; }
    public Guid SenderId { get; set; }
}
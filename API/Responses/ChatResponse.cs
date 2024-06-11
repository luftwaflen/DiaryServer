using Domain.Models;

namespace API.Responses;

public class ChatResponse
{
    public ChatResponse(Chat chat)
    {
        Id = chat.Id;
        Name = chat.Name;
        Messages = new List<MessageResponse>();
        var messages = chat.Messages;
        foreach (var message in messages)
        {
            Messages.Add(new MessageResponse(message));
        }
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual List<MessageResponse> Messages { get; set; }
}
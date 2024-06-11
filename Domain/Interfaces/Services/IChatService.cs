using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IChatService
{
    Task<List<Chat>> GetUserChats(Guid userId);
    Task<Chat> GetChat(Guid chatId);
    Task<Chat> UpdateChat(Guid chatId);
    Task DeleteChat(Guid chatId);
    Task AddMessage(Guid chatId, Guid userId, string messageText);
}
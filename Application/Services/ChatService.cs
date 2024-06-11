using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services;

public class ChatService : IChatService
{
    private readonly IUserRepository _userRepository;
    private readonly IChatRepository _chatRepository;
    private readonly IMessageRepository _messageRepository;

    public ChatService(IChatRepository chatRepository, IMessageRepository messageRepository, IUserRepository userRepository)
    {
        _chatRepository = chatRepository;
        _messageRepository = messageRepository;
        _userRepository = userRepository;
    }

    public async Task<List<Chat>> GetUserChats(Guid userId)
    {
        var users = await _userRepository.Get(u => u.Id == userId);
        var user = users.FirstOrDefault();
        return user.Chats;
    }

    public async Task<Chat> GetChat(Guid chatId)
    {
        var chats = await _chatRepository.Get(c => c.Id == chatId);
        var chat = chats.FirstOrDefault();
        return chat;
    }

    public async Task<Chat> UpdateChat(Guid chatId)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteChat(Guid chatId)
    {
        var chats = await _chatRepository.Get(c => c.Id == chatId);
        var chat = chats.FirstOrDefault();
        await _chatRepository.Delete(chat);
    }

    public async Task AddMessage(Guid chatId, Guid userId, string messageText)
    {
        var users = await _userRepository.Get(u => u.Id == userId);
        var user = users.FirstOrDefault();
        var chats = await _chatRepository.Get(c => c.Id == chatId);
        var chat = chats.FirstOrDefault();
        var message = new Message(messageText, user);
        chat.Messages.Add(message);
        await _messageRepository.Create(message);
        await _chatRepository.Update(chat);
    }
}
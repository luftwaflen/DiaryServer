using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Login(string login, string password)
    {
        var users = await _userRepository.Get(u => u.Login == login);
        var user = users.FirstOrDefault();
        if (user != null && user.Password == password) return user;
        return null;
    }
}
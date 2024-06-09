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

    public async Task Login(string login, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetUsers()
    {
        var users = await _userRepository.GetAll();
        return users;
    }
}
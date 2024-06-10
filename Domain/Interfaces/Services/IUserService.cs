using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IUserService
{
    Task<User> Login(string login, string password);
}
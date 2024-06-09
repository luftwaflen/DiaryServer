using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IUserService
{
    Task Login(string login, string password);
    Task<List<User>> GetUsers();
}
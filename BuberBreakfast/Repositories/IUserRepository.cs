using BuberBreakfast.Models;

namespace BuberBreakfast.Repositories;

public interface IUsersRepository
{
    Task CreateUser(User user);

    Task<User?> GetUser(Guid id);

    Task<User?> GetUserByUsername(string username);
}
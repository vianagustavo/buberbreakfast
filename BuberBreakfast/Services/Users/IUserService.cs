using BuberBreakfast.Models;

namespace BuberBreakfast.Services.Breakfasts;

public interface IUserService
{
    Task CreateUser(User user);
    Task<User?> GetUser(Guid id);
}
using BuberBreakfast.Models;
using BuberBreakfast.Repositories;

namespace BuberBreakfast.Services.Breakfasts;

public class UserService : IUserService
{
    private readonly IUsersRepository _repository;

    public UserService(IUsersRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateUser(User user)
    {
        await _repository.CreateUser(user);
    }

    public async Task<User?> GetUser(Guid id)
    {
        var user = await _repository.GetUser(id);

        return user;
    }
}

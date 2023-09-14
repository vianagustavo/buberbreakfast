using BuberBreakfast.Database;
using BuberBreakfast.Models;
using Microsoft.EntityFrameworkCore;
namespace BuberBreakfast.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly BreakfastContext _context;

    public UsersRepository(BreakfastContext context)
    {
        _context = context;
    }

    public async Task CreateUser(User user)
    {
        await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();
    }


    public async Task<User?> GetUser(Guid id)
    {
        var user = await _context.Users.FindAsync(id);

        return user;
    }

    public async Task<User?> GetUserByUsername(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.Username == username);

        return user;
    }
}

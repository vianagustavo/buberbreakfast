using BuberBreakfast.Database;
using BuberBreakfast.Models;
namespace BuberBreakfast.Repositories;

public class BreakfastRepository : IBreakfastsRepository
{
    private readonly BreakfastContext _context;

    public BreakfastRepository(BreakfastContext context)
    {
        _context = context;
    }

    public async Task CreateBreakfast(Breakfast breakfast)
    {
        await _context.Breakfasts.AddAsync(breakfast);

        await _context.SaveChangesAsync();
    }

    public async Task<Breakfast?> GetBreakfast(Guid id)
    {
        var breakfast = await _context.Breakfasts.FindAsync(id);

        return breakfast;
    }
}

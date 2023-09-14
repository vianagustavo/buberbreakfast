using BuberBreakfast.Models;

namespace BuberBreakfast.Repositories;

public interface IBreakfastsRepository
{
    Task CreateBreakfast(Breakfast breakfast);

    Task<Breakfast?> GetBreakfast(Guid id);
}
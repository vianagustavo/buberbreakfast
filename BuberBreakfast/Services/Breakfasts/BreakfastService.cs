using BuberBreakfast.Middlewares;
using BuberBreakfast.Models;
using BuberBreakfast.Repositories;
using ErrorOr;

namespace BuberBreakfast.Services.Breakfasts;

public class BreakfastService : IBreakfastService
{
    private static readonly Dictionary<Guid, Breakfast> _breakfasts = new();
    private readonly IBreakfastsRepository _repository;

    public BreakfastService(IBreakfastsRepository repository)
    {
        _repository = repository;
    }
    public async Task CreateBreakfast(Breakfast breakfast)
    {
        await _repository.CreateBreakfast(breakfast);
    }

    public async Task<Breakfast?> GetBreakfast(Guid id)
    {
        var breakfast = await _repository.GetBreakfast(id);

        return breakfast;
    }

    public void UpsertBreakfast(Breakfast breakfast)
    {
        _breakfasts[breakfast.Id] = breakfast;
    }

    public void DeleteBreakfast(Guid id)
    {
        _breakfasts.Remove(id);
    }
}

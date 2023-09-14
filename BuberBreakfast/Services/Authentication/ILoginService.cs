using BuberBreakfast.Models;
using BuberBreakfastContracts.Breakfast;

namespace BuberBreakfast.Services.Breakfasts;

public interface ILoginService
{
    Task<string?> ValidateUser(CreateUserRequest user);
}
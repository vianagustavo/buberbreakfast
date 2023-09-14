using BuberBreakfast.Models;

namespace BuberBreakfast.Services.Breakfasts;

public interface ITokenService
{
    string GenerateToken(User user);
}
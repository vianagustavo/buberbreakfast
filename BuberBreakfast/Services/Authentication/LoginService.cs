using BuberBreakfast.Repositories;
using BuberBreakfastContracts.Breakfast;

namespace BuberBreakfast.Services.Breakfasts;

public class LoginService : ILoginService
{
    private readonly IUsersRepository _repository;
    private readonly ITokenService _tokenService;

    public LoginService(IUsersRepository repository, ITokenService tokenService)
    {
        _repository = repository;
        _tokenService = tokenService;
    }
    public async Task<string?> ValidateUser(CreateUserRequest userRequest)
    {
        var user = await _repository.GetUserByUsername(userRequest.Username);

        if (user != null)
        {
            if (user.Password == userRequest.Password)
            {
                var token = _tokenService.GenerateToken(user);

                return token;
            }
        }

        return null;
    }
}
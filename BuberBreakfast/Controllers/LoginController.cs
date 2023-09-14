using BuberBreakfast.Services.Breakfasts;
using BuberBreakfastContracts.Breakfast;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("user/login")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost()]
    public async Task<IActionResult> LoginUser(CreateUserRequest request)
    {
        var token = await _loginService.ValidateUser(request);

        return Ok(new { token });
    }
}
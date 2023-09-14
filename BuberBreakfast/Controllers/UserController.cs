using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;
using BuberBreakfastContracts.Breakfast;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost()]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        var user = new User(
            Guid.NewGuid(),
            request.Username,
            request.Password,
            DateTime.UtcNow,
            DateTime.UtcNow
        );

        await _userService.CreateUser(user);

        var response = new User(
            user.Id,
            user.Username,
            user.Password,
            user.CreatedAt,
            user.UpdatedAt
        );

        return CreatedAtAction(actionName: nameof(GetUser), routeValues: new { id = user.Id }, value: response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        User? user = await _userService.GetUser(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }
}
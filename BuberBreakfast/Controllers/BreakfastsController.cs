using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;
using BuberBreakfastContracts.Breakfast;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("breakfasts")]
[Authorize(Roles = "user")]
public class BreakfastsController : ControllerBase
{
    private readonly IBreakfastService _breakfastService;

    public BreakfastsController(IBreakfastService breakfastService)
    {
        _breakfastService = breakfastService;
    }

    [HttpPost()]
    public async Task<IActionResult> CreateBreakfast(CreateBreakfastRequest request)
    {
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            DateTime.UtcNow,
            DateTime.UtcNow,
            DateTime.UtcNow
        );

        await _breakfastService.CreateBreakfast(breakfast);

        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime
        );

        return CreatedAtAction(actionName: nameof(GetBreakfast), routeValues: new { id = breakfast.Id }, value: response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetBreakfast(Guid id)
    {
        Breakfast? breakfast = await _breakfastService.GetBreakfast(id);

        if (breakfast == null)
        {
            return NotFound();
        }

        return Ok(breakfast);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        var breakfast = new Breakfast(
           id,
           request.Name,
           request.Description,
           request.StartDateTime,
           request.EndDateTime,
           DateTime.UtcNow
       );

        _breakfastService.UpsertBreakfast(breakfast);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        _breakfastService.DeleteBreakfast(id);

        return NoContent();
    }
}
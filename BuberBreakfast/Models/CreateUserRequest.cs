namespace BuberBreakfastContracts.Breakfast;

public record CreateUserRequest(
    string Username,
    string Password
);
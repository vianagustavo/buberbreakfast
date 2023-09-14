namespace BuberBreakfast.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public User(
        Guid id,
        string username,
        string password,
        DateTime createdAt,
        DateTime updatedAt)
    {
        Id = id;
        Username = username;
        Password = password;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}
namespace BuberBreakfast.Models;

public class Breakfast
{
    public Guid Id { get; set;}
    public string Name { get; set;}
    public string Description { get; set;}
    public DateTime StartDateTime { get; set;}
    public DateTime EndDateTime { get; set;}
    public DateTime LastModifiedDateTime { get; set;}

    public Breakfast(
        Guid id,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime lastModifiedDateTime)
    {
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
    }
}
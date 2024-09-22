namespace WebApplication2.Models;

public class Transmission : Vehicle
{
    public string? Name { get; set; }

    public Transmission(int id, string? name)
    {
        Id = id;
        Name = name;
    }
}

namespace WebApplication2.Models;

public class Fuel : Vehicle
{
    public string? Name { get; set; }

    public Fuel(int id, string? name)
    {
        Id = id;
        Name = name;
    }
}

namespace WebApplication2.Models;

public class Color : Vehicle
{
    public string? Name { get; set; }

    public Color(int id, string? name)
    {
        Id = id;
        Name = name;
    }
}

using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Service;
public class ColorService
{
    ColorRepository colorRepository = new ColorRepository();

    public void Add(Color color)
    {
        Color created = colorRepository.Add(color);
        Console.WriteLine(created);
    }
    public List<Color> GetAll()
    {
        return colorRepository.GetAll();
    }
    public Color GetById(int id)
    {
        return colorRepository.GetById(id);
    }
    public Color Remove(int id)
    {
        return colorRepository.Remove(id);
    }
    public Color Update(Color color)
    {
        return colorRepository.Update(color);
    }
}

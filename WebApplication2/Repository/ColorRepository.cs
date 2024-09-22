using WebApplication2.Models;

namespace WebApplication2.Repository;

public class ColorRepository : CommonRepository<Color>
{

    List<Color> colors = new List<Color>()
{
    new Color(1,"Siyah"),
    new Color(2,"Beyaz"),
    new Color(3,"Gri"),
    new Color(4,"Lacivert"),
    new Color(5,"Kırmızı")
};
    public override Color Add(Color created)
    {
        colors.Add(created);
        return created;
    }

    public override List<Color> GetAll()
    {
        return colors;
    }

    public override Color GetById(int id)
    {
        return colors.FirstOrDefault(c => c.Id == id);
    }

    public override Color Remove(int id)
    {
        Color deletedColor = GetById(id);
        colors.Remove(deletedColor);
        return deletedColor;
    }

    public override Color Update(Color updated)
    {
        Color newColor = GetById(updated.Id);
        if(newColor != null)
        {
            newColor.Id = updated.Id;
            newColor.Name = updated.Name;
            return newColor;
        }
        return null;
    }
}

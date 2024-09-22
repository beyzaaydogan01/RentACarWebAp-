using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Service;

public class FuelService
{
    FuelRepository fuelRepository = new FuelRepository();

    public void Add(Fuel fuel)
    {
        Fuel created = fuelRepository.Add(fuel);
        Console.WriteLine($"Yakıt bilgisi eklendi: {created}");
    }
    public List<Fuel> GetAll()
    {
        return fuelRepository.GetAll();
    }
    public Fuel? GetById(int id)
    {
        return fuelRepository.GetById(id);
    }
    public Fuel Remove(int id)
    {
        return fuelRepository.Remove(id);
    }
    public Fuel Update(Fuel fuel)
    {
        return fuelRepository.Update(fuel);
    }
}

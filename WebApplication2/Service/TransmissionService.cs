using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Service;

public class TransmissionService
{
    TransmissionRepository transmissionRepository = new TransmissionRepository();

    public void Add(Transmission transmission)
    {
        Transmission created = transmissionRepository.Add(transmission);
        Console.WriteLine(created);
    }
    public List<Transmission> GetAll()
    {
        return transmissionRepository.GetAll();
    }
    public Transmission GetById(int id)
    {
        return transmissionRepository.GetById(id);  
    }
    public Transmission Remove(int id)
    {
        return transmissionRepository.Remove(id);
    }
    public Transmission Update(Transmission transmission)
    {
        return transmissionRepository.Update(transmission);
    }
}

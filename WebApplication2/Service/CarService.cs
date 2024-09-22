using WebApplication2.Controllers;
using WebApplication2.Models;
using WebApplication2.Models.Dtos;
using WebApplication2.Repository;

namespace WebApplication2.Service;

public class CarService
{
    CarRepository carRepository = new CarRepository();

    public void Add(Car car)
    {
        Car created = carRepository.Add(car);
        Console.WriteLine($"Araba eklendi: {created}");
    }
    public List<Car> GetAll()
    {
        return carRepository.GetAll();
    }
    public Car? GetById(int id)
    {
        return carRepository.GetById(id);
    }
    public Car Remove(int id)
    {
        return carRepository.Remove(id);
    }
    public Car Update(Car car)
    {
        return carRepository.Update(car);
    }
    public List<CarDetailDto> GetAllDetails()
    {
        return carRepository.GetAllDetails();   
    }
   public List<CarDetailDto> GetAllDetailsByFuelId(int fuelId)
    {
        return carRepository.GetAllDetailsByFuelId(fuelId);
    }
    public List<CarDetailDto> GetAllCarDetailsByColorId(int colorId)
    {
        return carRepository.GetAllDetailsByColorId(colorId);
    }
    public List<CarDetailDto> GetAllDetailsByPriceRange(double min, double max)
    {
        return carRepository.GetAllDetailsByPriceRange((double)min, (double)max);
    }
    public List<CarDetailDto> GetAllDetailsByBrandNameContains(string brandName)
    {
        return carRepository.GetAllDetailsByBrandNameContains((string)brandName);
    }
    public List<CarDetailDto> GetAllDetailsByModelNameContains(string modelName)
    {
        return carRepository.GetAllDetailsByModelNameContains((string)modelName);
    }
    public CarDetailDto? GetDetailById(int categoryId)
    {
        return carRepository.GetDetailById(categoryId);
    }
    public List<CarDetailDto> GetAllDetailsByKilometerRange(int min, int max)
    {
        return carRepository.GetAllDetailsByKilometerRange(min, max);
    }
}

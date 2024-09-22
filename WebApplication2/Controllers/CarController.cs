using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.Dtos;
using WebApplication2.Repository;
using WebApplication2.Service;

namespace WebApplication2.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
    CarService carService = new CarService();

    [HttpPost("Add",Name = "Add")]
    public Car Add([FromBody] Car car) //FromBody ile car parametrelerini alırız
    {
        carService.Add(car);
        return car;
    }

    [HttpGet("GetAll",Name = "GetAllCars")]
    public List<Car> GetAllCars()
    {
        return carService.GetAll();
    }
    [HttpGet("{id}", Name = "GetById")]
    public ActionResult<Car> GetCarById(int id) //ActionResult NotFound sonucunu döndürmek için kullanıldı
    {
        var result = carService.GetById(id);
        if (result == null)
        {
            return NotFound(); //404 not found
        }
        return Ok(result);
    }
    [HttpDelete("{id}", Name = "Remove")]
    public ActionResult<Car> Remove(int id)
    {
        var result = carService.Remove(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPut("{id}", Name = "Update")]
    public ActionResult<Car> Update(int id, [FromBody] Car car)
    {
        if (id != car.Id)
        {
            return BadRequest("Id eşleşmiyor");
        }
        var updatedCar = carService.Update(car);
        if (updatedCar == null)
        {
            return NotFound();
        }
        return Ok(updatedCar);
    }
    [HttpGet("details", Name = "GetAllCarDetails")]
    public ActionResult<List<CarDetailDto>> GetAllCarDetails()
    {
        var result = carService.GetAllDetails();
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet("fuel/{fuelId}", Name = "GetAllDetailsByFuelId")]
    public ActionResult<List<CarDetailDto>> GetAllDetailsByFuelId(int fuelId)
    {
        var result = carService.GetAllDetailsByFuelId(fuelId);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet("color/{colorId}", Name = "GetAllDetailsByColorId")]
    public ActionResult<List<CarDetailDto>> GetAllDetailsByColorId(int colorId)
    {
        var result = carService.GetAllCarDetailsByColorId(colorId);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet("priceRange/{min} {max}", Name = "GetAllDetailsByPriceRange")]
    public ActionResult<List<CarDetailDto>> GetAllDetailsByPriceRange(double min, double max)
    {
        var result = carService.GetAllDetailsByPriceRange(min, max);
        if(result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpGet("containsBrand/{brandName}", Name = "GetAllDetailsByBrandNameContains")]
    public ActionResult<List<CarDetailDto>> GetAllDetailsByBrandNameContains(string brandName)
    {
        var result = carService.GetAllDetailsByBrandNameContains(brandName);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpGet("containsModel/{modelName}", Name = "GetAllDetailsByModelNameContains")]
    public ActionResult<List<CarDetailDto>> GetAllDetailsByModelNameContains(string modelName)
    {
        var result = carService.GetAllDetailsByModelNameContains(modelName);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpGet("categoryId/{categoryId}", Name = "GetDetailByI")]
    public ActionResult<CarDetailDto> GetDetailById(int categoryId)
    {
        var result = carService.GetDetailById(categoryId);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    [HttpGet("kilometer/{min} {max}", Name = "GetAllDetailsByKilometerRange")]
    public ActionResult<List<CarDetailDto>> GetAllDetailsByKilometerRange(int min, int max)
    {
        var result = carService.GetAllDetailsByKilometerRange(min, max);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}

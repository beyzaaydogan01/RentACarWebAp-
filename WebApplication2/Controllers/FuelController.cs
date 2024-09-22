using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Controllers;
[ApiController]
[Route("[controller]")]
public class FuelController : Controller
{
    FuelService fuelService = new FuelService();

    [HttpPost (Name = "AddFuel")]
    public Fuel AddFuel([FromBody] Fuel fuel)
    {
        fuelService.Add(fuel);
        return fuel;
    }

    [HttpGet (Name = "GetAllFuel")]
    public List<Fuel> GetAllFuel()
    {
        return fuelService.GetAll();    
    }

    [HttpGet ("{id}", Name = "GetByFuelId")]
    public ActionResult<Fuel> GetByFuelId(int id)
    {
        var result = fuelService.GetById (id);
        if(result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpDelete ("{id}", Name = "RemoveFuel")]
    public ActionResult<Fuel> RemoveFuel(int id)
    {
        var result = fuelService.Remove(id);
        if(result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPut ("{id}", Name = "UpdateFuel")]
    public ActionResult<Fuel> UpdateFuel(int id, [FromBody] Fuel fuel)
    {
        if(id != fuel.Id)
        {
            return BadRequest("Id eşleşmiyor");
        }
        var result = fuelService.Update(fuel);
        if(result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}

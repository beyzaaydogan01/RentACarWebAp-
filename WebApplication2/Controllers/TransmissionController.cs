using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Controllers;
[ApiController]
[Route("[controller]")]
public class TransmissionController : Controller
{
    TransmissionService transmissionService = new TransmissionService();

    [HttpPost(Name = "AddTransmission")]
    public Transmission AddTransmission([FromBody] Transmission transmission)
    {
        transmissionService.Add(transmission);
        return transmission;
    }

    [HttpGet(Name = "GetAllTransmission")]
    public List<Transmission> GetAllTransmissions()
    {
        return transmissionService.GetAll();
    }

    [HttpGet("{id}",Name = "GetByTransmissionId")]
    public ActionResult<Transmission> GetByTransmissionId(int id)
    {
       var result = transmissionService.GetById(id);    
       if(result == null)
        {
            return NotFound();
        }
       return Ok(result);
    }

    [HttpDelete ("{id}",Name = "RemoveTransmission")]
    public ActionResult<Transmission> RemoveTransmission(int id)
    {
        var result = transmissionService.Remove(id);
        if( result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPut("{id}",Name = "UpdateTransmission")]
    public ActionResult<Transmission> UpdateTransmission(int id, [FromBody] Transmission transmission)
    {
        var result = transmissionService.Update(transmission);
        if (id != transmission.Id)
        {
            return BadRequest();
        }
        if(result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}

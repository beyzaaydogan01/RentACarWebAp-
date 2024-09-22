using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Controllers;

[ApiController]
[Route("[controller]")]
public class ColorController : ControllerBase
{
    ColorService colorService = new ColorService();

    [HttpPost(Name = "AddColor")]
    public Color AddColor([FromBody] Color color)
    {
        colorService.Add(color);
        return color;
    }

    [HttpGet(Name = "GetAllColors")]
    public List<Color> GetAllColor()
    {
        var result = colorService.GetAll();
        return result;
    }

    [HttpGet("{id}", Name = "GetByColorId")]
    public ActionResult<Color> GetByColorId(int id)
    {
        var result = colorService.GetById(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpDelete("{id}", Name ="RemoveColor")]
    public ActionResult<Color> RemoveColor(int id)
    {
        var result = colorService.Remove(id);
        if(result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPut("{id}", Name = "UpdateColor")]
    public ActionResult<Color> UpdateColor(int id,[FromBody] Color color)
    {
        if(id != color.Id)
        {
            return BadRequest("Id eşleşmiyor");
        }
        var result = colorService.Update(color);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}

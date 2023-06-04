using Microsoft.AspNetCore.Mvc;
using MortgageAutomation.Models;
using MortgageAutomation.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MortgageAutomation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> Get()
        {
            var properties = await _propertyService.GetPropertiesAsync();
            return Ok(properties);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> Get(int id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }
            return Ok(property);
        }

        [HttpPost]
        public async Task<ActionResult<Property>> Post(Property property)
        {
            var createdProperty = await _propertyService.AddPropertyAsync(property);
            return CreatedAtAction(nameof(Get), new { id = createdProperty.AppId }, createdProperty);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Property property)
        {
            if (id != property.AppId)
            {
                return BadRequest();
            }
            await _propertyService.UpdatePropertyAsync(property);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _propertyService.DeletePropertyAsync(id);
            return NoContent();
        }
    }
}

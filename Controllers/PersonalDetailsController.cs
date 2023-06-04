using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MortgageAutomation.Models;
using MortgageAutomation.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MortgageAutomation.Controllers
{
    [ApiController]
    // Allow CORS for all origins. (Caution!)
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]")]
    public class PersonalDetailsController : ControllerBase
    {
        private readonly IPersonalService _personalService;

        public PersonalDetailsController(IPersonalService personalService)
        {
            _personalService = personalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalDetails>>> Get()
        {
            var personalDetails = await _personalService.GetPersonalDetailsAsync();
            return Ok(personalDetails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalDetails>> Get(int id)
        {
            var personalDetails = await _personalService.GetPersonalDetailsByIdAsync(id);
            if (personalDetails == null)
            {
                return NotFound();
            }
            return Ok(personalDetails);
        }

        [HttpPost]
        public async Task<ActionResult<PersonalDetails>> Post(PersonalDetails personalDetails)
        {
            var createdPersonalDetails = await _personalService.AddPersonalDetailsAsync(personalDetails);
            return CreatedAtAction(nameof(Get), new { id = createdPersonalDetails.Id }, createdPersonalDetails);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PersonalDetails personalDetails)
        {
            if (id != personalDetails.Id)
            {
                return BadRequest();
            }
            await _personalService.UpdatePersonalDetailsAsync(personalDetails);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _personalService.DeletePersonalDetailsAsync(id);
            return NoContent();
        }
    }
}

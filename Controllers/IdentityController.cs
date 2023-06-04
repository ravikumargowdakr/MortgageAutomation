using Microsoft.AspNetCore.Mvc;
using MortgageAutomation.Models;
using MortgageAutomation.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MortgageAutomation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityProof>>> Get()
        {
            var identities = await _identityService.GetIdentitiesAsync();
            return Ok(identities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IdentityProof>> Get(int id)
        {
            var identity = await _identityService.GetIdentityByIdAsync(id);
            if (identity == null)
            {
                return NotFound();
            }
            return Ok(identity);
        }

        [HttpPost]
        public async Task<ActionResult<IdentityProof>> Post(IdentityProof identity)
        {
            var createdIdentity = await _identityService.AddIdentityAsync(identity);
            return CreatedAtAction(nameof(Get), new { id = createdIdentity.Id }, createdIdentity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, IdentityProof identity)
        {
            if (id != identity.Id)
            {
                return BadRequest();
            }
            await _identityService.UpdateIdentityAsync(identity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _identityService.DeleteIdentityAsync(id);
            return NoContent();
        }
    }
}

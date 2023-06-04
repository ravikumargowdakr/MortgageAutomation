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
    
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> Get()
        {
            var addresses = await _addressService.GetAddressesAsync();
            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> Get(int id)
        {
            var address = await _addressService.GetAddressByIdAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return Ok(address);
        }

        [HttpPost]
        public async Task<ActionResult<Address>> Post(Address address)
        {
            var createdAddress = await _addressService.AddAddressAsync(address);
            return CreatedAtAction(nameof(Get), new { id = createdAddress.Id }, createdAddress);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }
            await _addressService.UpdateAddressAsync(address);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _addressService.DeleteAddressAsync(id);
            return NoContent();
        }
    }
}

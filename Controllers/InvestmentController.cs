using Microsoft.AspNetCore.Mvc;
using MortgageAutomation.Models;
using MortgageAutomation.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MortgageAutomation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentService _investmentService;

        public InvestmentController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investment>>> Get()
        {
            var investments = await _investmentService.GetInvestmentsAsync();
            return Ok(investments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Investment>> Get(int id)
        {
            var investment = await _investmentService.GetInvestmentByIdAsync(id);
            if (investment == null)
            {
                return NotFound();
            }
            return Ok(investment);
        }

        [HttpPost]
        public async Task<ActionResult<Investment>> Post(Investment investment)
        {
            var createdInvestment = await _investmentService.AddInvestmentAsync(investment);
            return CreatedAtAction(nameof(Get), new { id = createdInvestment.Id }, createdInvestment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Investment investment)
        {
            if (id != investment.Id)
            {
                return BadRequest();
            }
            await _investmentService.UpdateInvestmentAsync(investment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _investmentService.DeleteInvestmentAsync(id);
            return NoContent();
        }
    }
}

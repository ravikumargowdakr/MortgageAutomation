using Microsoft.AspNetCore.Mvc;
using MortgageAutomation.Models;
using MortgageAutomation.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MortgageAutomation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _incomeService;

        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Income>>> Get()
        {
            var incomes = await _incomeService.GetIncomesAsync();
            return Ok(incomes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Income>> Get(int id)
        {
            var income = await _incomeService.GetIncomeByIdAsync(id);
            if (income == null)
            {
                return NotFound();
            }
            return Ok(income);
        }

        [HttpPost]
        public async Task<ActionResult<Income>> Post(Income income)
        {
            var createdIncome = await _incomeService.AddIncomeAsync(income);
            return CreatedAtAction(nameof(Get), new { id = createdIncome.Id }, createdIncome);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Income income)
        {
            if (id != income.Id)
            {
                return BadRequest();
            }

            await _incomeService.UpdateIncomeAsync(income);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _incomeService.DeleteIncomeAsync(id);
            return NoContent();
        }
    }
}

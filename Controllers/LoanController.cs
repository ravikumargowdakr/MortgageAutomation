using Microsoft.AspNetCore.Mvc;
using MortgageAutomation.Models;
using MortgageAutomation.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MortgageAutomation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> Get()
        {
            var loans = await _loanService.GetLoansAsync();
            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Loan>> Get(int id)
        {
            var loan = await _loanService.GetLoanByIdAsync(id);
            if (loan == null)
            {
                return NotFound();
            }
            return Ok(loan);
        }

        [HttpPost]
        public async Task<ActionResult<Loan>> Post(Loan loan)
        {
            var createdLoan = await _loanService.AddLoanAsync(loan);
            return CreatedAtAction(nameof(Get), new { id = createdLoan.Id }, createdLoan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Loan loan)
        {
            if (id != loan.Id)
            {
                return BadRequest();
            }
            await _loanService.UpdateLoanAsync(loan);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _loanService.DeleteLoanAsync(id);
            return NoContent();
        }
    }
}

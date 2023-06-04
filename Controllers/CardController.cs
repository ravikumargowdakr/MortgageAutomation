using Microsoft.AspNetCore.Mvc;
using MortgageAutomation.Models;
using MortgageAutomation.Services;
using MortgageAutomation.Context;

namespace MortgageAutomation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditCard>>> Get()
        {
            var cards = await _cardService.GetCardsAsync();
            return Ok(cards);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CreditCard>> Get(int id)
        {
            var card = await _cardService.GetCardByIdAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            return Ok(card);
        }
        [HttpPost]
        public async Task<ActionResult<CreditCard>> Post(CreditCard card)
        {
            var createdCard = await _cardService.AddCardAsync(card);
            return CreatedAtAction(nameof(Get), new { id = createdCard.Id }, createdCard);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CreditCard card)
        {
            if (id != card.Id)
            {
                return BadRequest();
            }
            await _cardService.UpdateCardAsync(card);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cardService.DeleteCardSync(id);
            return NoContent();
        }
    }
}


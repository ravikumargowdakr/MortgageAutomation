using MortgageAutomation.Models;
using MortgageAutomation.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MortgageAutomation.Services
{
    public class CardService:ICardService
    {
        private readonly MortgageDbContext _context;
        public CardService(MortgageDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CreditCard>> GetCardsAsync()
        {
            return await _context.Cards.ToListAsync();
        }
        public async Task<CreditCard> GetCardByIdAsync(int id)
        {
            return await _context.Cards.FindAsync(id);
        }
        public async Task<CreditCard> AddCardAsync(CreditCard card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
            return card;
        }
        public async Task<CreditCard> UpdateCardAsync(CreditCard card)
        {
            _context.Cards.Update(card);
            await _context.SaveChangesAsync();
            return card;
        }
        public async Task DeleteCardSync(int id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card == null)
            {
                throw new ArgumentException($"Card with ID {id} not found.");
            }
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
        }
    }
}

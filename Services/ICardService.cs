using MortgageAutomation.Models;

namespace MortgageAutomation.Services
{
    public interface ICardService
    {
        Task<IEnumerable<CreditCard>> GetCardsAsync();
        Task<CreditCard> GetCardByIdAsync(int id);
        Task<CreditCard> AddCardAsync(CreditCard card);
        Task<CreditCard> UpdateCardAsync(CreditCard card);
        Task DeleteCardSync(int id);
    }
}

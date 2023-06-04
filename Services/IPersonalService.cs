using MortgageAutomation.Models;

namespace MortgageAutomation.Services
{
    public interface IPersonalService
    {
        Task<IEnumerable<PersonalDetails>> GetPersonalDetailsAsync();
        Task<PersonalDetails> GetPersonalDetailsByIdAsync(int id);
        Task<PersonalDetails> AddPersonalDetailsAsync(PersonalDetails personalDetails);
        Task<PersonalDetails> UpdatePersonalDetailsAsync(PersonalDetails personalDetails);
        Task DeletePersonalDetailsAsync(int id);
    }
}

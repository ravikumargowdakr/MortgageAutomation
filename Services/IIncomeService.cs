using MortgageAutomation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MortgageAutomation.Services
{
    public interface IIncomeService
    {
        Task<IEnumerable<Income>> GetIncomesAsync();
        Task<Income> GetIncomeByIdAsync(int id);
        Task<Income> AddIncomeAsync(Income income);
        Task<Income> UpdateIncomeAsync(Income income);
        Task DeleteIncomeAsync(int id);
    }
}

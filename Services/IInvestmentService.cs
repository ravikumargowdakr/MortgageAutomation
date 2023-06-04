using MortgageAutomation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MortgageAutomation.Services
{
    public interface IInvestmentService
    {
        Task<IEnumerable<Investment>> GetInvestmentsAsync();
        Task<Investment> GetInvestmentByIdAsync(int id);
        Task<Investment> AddInvestmentAsync(Investment investment);
        Task<Investment> UpdateInvestmentAsync(Investment investment);
        Task DeleteInvestmentAsync(int id);
    }
}

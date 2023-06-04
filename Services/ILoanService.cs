using MortgageAutomation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MortgageAutomation.Services
{
    public interface ILoanService
    {
        Task<IEnumerable<Loan>> GetLoansAsync();
        Task<Loan> GetLoanByIdAsync(int id);
        Task<Loan> AddLoanAsync(Loan loan);
        Task<Loan> UpdateLoanAsync(Loan loan);
        Task DeleteLoanAsync(int id);
    }
}

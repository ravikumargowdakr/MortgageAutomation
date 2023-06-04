using MortgageAutomation.Models;
using MortgageAutomation.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageAutomation.Services
{
    public class LoanService : ILoanService
    {
        private readonly MortgageDbContext _context;

        public LoanService(MortgageDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Loan>> GetLoansAsync()
        {
            return await _context.Loans.ToListAsync();
        }

        public async Task<Loan> GetLoanByIdAsync(int id)
        {
            return await _context.Loans.FindAsync(id);
        }

        public async Task<Loan> AddLoanAsync(Loan loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
            return loan;
        }

        public async Task<Loan> UpdateLoanAsync(Loan loan)
        {
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
            return loan;
        }

        public async Task DeleteLoanAsync(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan == null)
            {
                throw new ArgumentException($"Loan with ID {id} not found.");
            }
            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
        }
    }
}

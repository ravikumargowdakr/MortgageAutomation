using MortgageAutomation.Models;
using MortgageAutomation.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace MortgageAutomation.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly MortgageDbContext _context;
        public IncomeService(MortgageDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Income>> GetIncomesAsync()
        {
            return await _context.Incomes.ToListAsync();
        }

        public async Task<Income> GetIncomeByIdAsync(int id)
        {
            return await _context.Incomes.FindAsync(id);
        }

        public async Task<Income> AddIncomeAsync(Income income)
        {
            _context.Incomes.Add(income);
            await _context.SaveChangesAsync();
            return income;
        }

        public async Task<Income> UpdateIncomeAsync(Income income)
        {
            _context.Incomes.Update(income);
            await _context.SaveChangesAsync();
            return income;
        }

        public async Task DeleteIncomeAsync(int id)
        {
            var income = await _context.Incomes.FindAsync(id);
            if (income == null)
            {
                throw new ArgumentException($"Income with ID {id} not found.");
            }
            _context.Incomes.Remove(income);
            await _context.SaveChangesAsync();
        }
    }
}

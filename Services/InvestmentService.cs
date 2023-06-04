﻿using MortgageAutomation.Models;
using MortgageAutomation.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageAutomation.Services
{
    public class InvestmentService : IInvestmentService
    {
        private readonly MortgageDbContext _context;

        public InvestmentService(MortgageDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Investment>> GetInvestmentsAsync()
        {
            return await _context.Investments.ToListAsync();
        }

        public async Task<Investment> GetInvestmentByIdAsync(int id)
        {
            return await _context.Investments.FindAsync(id);
        }

        public async Task<Investment> AddInvestmentAsync(Investment investment)
        {
            _context.Investments.Add(investment);
            await _context.SaveChangesAsync();
            return investment;
        }

        public async Task<Investment> UpdateInvestmentAsync(Investment investment)
        {
            _context.Investments.Update(investment);
            await _context.SaveChangesAsync();
            return investment;
        }

        public async Task DeleteInvestmentAsync(int id)
        {
            var investment = await _context.Investments.FindAsync(id);
            if (investment == null)
            {
                throw new ArgumentException($"Investment with ID {id} not found.");
            }
            _context.Investments.Remove(investment);
            await _context.SaveChangesAsync();
        }
    }
}

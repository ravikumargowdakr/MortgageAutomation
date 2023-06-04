using Microsoft.EntityFrameworkCore;
using MortgageAutomation.Context;
using MortgageAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageAutomation.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly MortgageDbContext _context;

        public IdentityService(MortgageDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IdentityProof>> GetIdentitiesAsync()
        {
            return await _context.IdentityProofs.ToListAsync();
        }

        public async Task<IdentityProof> GetIdentityByIdAsync(int id)
        {
            return await _context.IdentityProofs.FindAsync(id);
        }

        public async Task<IdentityProof> AddIdentityAsync(IdentityProof identity)
        {
            _context.IdentityProofs.Add(identity);
            await _context.SaveChangesAsync();
            return identity;
        }

        public async Task<IdentityProof> UpdateIdentityAsync(IdentityProof identity)
        {
            _context.IdentityProofs.Update(identity);
            await _context.SaveChangesAsync();
            return identity;
        }

        public async Task DeleteIdentityAsync(int id)
        {
            var identity = await _context.IdentityProofs.FindAsync(id);
            if (identity == null)
            {
                throw new ArgumentException($"Identity with ID {id} not found.");
            }
            _context.IdentityProofs.Remove(identity);
            await _context.SaveChangesAsync();
        }
    }
}

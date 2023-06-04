using Microsoft.EntityFrameworkCore;
using MortgageAutomation.Context;
using MortgageAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageAutomation.Services
{
    public class PersonalService : IPersonalService
    {
        private readonly MortgageDbContext _context;

        public PersonalService(MortgageDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PersonalDetails>> GetPersonalDetailsAsync()
        {
            return await _context.PersonalDetails.ToListAsync();
        }

        public async Task<PersonalDetails> GetPersonalDetailsByIdAsync(int id)
        {
            return await _context.PersonalDetails.FindAsync(id);
        }

        public async Task<PersonalDetails> AddPersonalDetailsAsync(PersonalDetails personalDetails)
        {
            _context.PersonalDetails.Add(personalDetails);
            await _context.SaveChangesAsync();
            return personalDetails;
        }

        public async Task<PersonalDetails> UpdatePersonalDetailsAsync(PersonalDetails personalDetails)
        {
            _context.PersonalDetails.Update(personalDetails);
            await _context.SaveChangesAsync();
            return personalDetails;
        }

        public async Task DeletePersonalDetailsAsync(int id)
        {
            var personalDetails = await _context.PersonalDetails.FindAsync(id);
            if (personalDetails == null)
            {
                throw new ArgumentException($"Personal details with ID {id} not found.");
            }
            _context.PersonalDetails.Remove(personalDetails);
            await _context.SaveChangesAsync();
        }
    }
}

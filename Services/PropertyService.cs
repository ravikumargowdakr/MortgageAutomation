using MortgageAutomation.Models;
using MortgageAutomation.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageAutomation.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly MortgageDbContext _context;

        public PropertyService(MortgageDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Property>> GetPropertiesAsync()
        {
            return await _context.Properties.ToListAsync();
        }

        public async Task<Property> GetPropertyByIdAsync(int id)
        {
            return await _context.Properties.FindAsync(id);
        }

        public async Task<Property> AddPropertyAsync(Property property)
        {
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
            return property;
        }

        public async Task<Property> UpdatePropertyAsync(Property property)
        {
            _context.Properties.Update(property);
            await _context.SaveChangesAsync();
            return property;
        }

        public async Task DeletePropertyAsync(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property == null)
            {
                throw new ArgumentException($"Property with ID {id} not found.");
            }
            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();
        }
    }
}

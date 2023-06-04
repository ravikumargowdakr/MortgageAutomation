using Microsoft.EntityFrameworkCore;
using MortgageAutomation.Context;
using MortgageAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageAutomation.Services
{
    public class AddressService : IAddressService
    {
        private readonly MortgageDbContext _context;

        public AddressService(MortgageDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> GetAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task<Address> AddAddressAsync(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<Address> UpdateAddressAsync(Address address)
        {
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task DeleteAddressAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                throw new ArgumentException($"Address with ID {id} not found.");
            }
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
        }
    }
}

using MortgageAutomation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MortgageAutomation.Services
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAddressesAsync();
        Task<Address> GetAddressByIdAsync(int id);
        Task<Address> AddAddressAsync(Address address);
        Task<Address> UpdateAddressAsync(Address address);
        Task DeleteAddressAsync(int id);
    }
}

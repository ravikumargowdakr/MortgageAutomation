using MortgageAutomation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MortgageAutomation.Services
{
    public interface IPropertyService
    {
        Task<IEnumerable<Property>> GetPropertiesAsync();
        Task<Property> GetPropertyByIdAsync(int id);
        Task<Property> AddPropertyAsync(Property property);
        Task<Property> UpdatePropertyAsync(Property property);
        Task DeletePropertyAsync(int id);
    }
}
using MortgageAutomation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MortgageAutomation.Services
{
    public interface IIdentityService
    {
        Task<IEnumerable<IdentityProof>> GetIdentitiesAsync();
        Task<IdentityProof> GetIdentityByIdAsync(int id);
        Task<IdentityProof> AddIdentityAsync(IdentityProof identity);
        Task<IdentityProof> UpdateIdentityAsync(IdentityProof identity);
        Task DeleteIdentityAsync(int id);
    }
}

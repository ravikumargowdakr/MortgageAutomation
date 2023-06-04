using MortgageAutomation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MortgageAutomation.Services
{
    public interface IAssetService
    {
        Task<IEnumerable<Asset>> GetAssetsAsync();
        Task<Asset> GetAssetByIdAsync(int id);
        Task<Asset> AddAssetAsync(Asset asset);
        Task<Asset> UpdateAssetAsync(Asset asset);
        Task DeleteAssetAsync(int id);
    }
}

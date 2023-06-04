using Microsoft.EntityFrameworkCore;
using MortgageAutomation.Context;
using MortgageAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageAutomation.Services
{
    public class AssetService : IAssetService
    {
        private readonly MortgageDbContext _context;

        public AssetService(MortgageDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asset>> GetAssetsAsync()
        {
            return await _context.Assets.ToListAsync();
        }

        public async Task<Asset> GetAssetByIdAsync(int id)
        {
            return await _context.Assets.FindAsync(id);
        }

        public async Task<Asset> AddAssetAsync(Asset asset)
        {
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();
            return asset;
        }

        public async Task<Asset> UpdateAssetAsync(Asset asset)
        {
            _context.Assets.Update(asset);
            await _context.SaveChangesAsync();
            return asset;
        }

        public async Task DeleteAssetAsync(int id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
            {
                throw new ArgumentException($"Asset with ID {id} not found.");
            }
            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();
        }
    }
}

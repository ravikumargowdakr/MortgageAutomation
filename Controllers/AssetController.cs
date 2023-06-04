using Microsoft.AspNetCore.Mvc;
using MortgageAutomation.Models;
using MortgageAutomation.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MortgageAutomation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asset>>> Get()
        {
            var assets = await _assetService.GetAssetsAsync();
            return Ok(assets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Asset>> Get(int id)
        {
            var asset = await _assetService.GetAssetByIdAsync(id);
            if (asset == null)
            {
                return NotFound();
            }
            return Ok(asset);
        }

        [HttpPost]
        public async Task<ActionResult<Asset>> Post(Asset asset)
        {
            var createdAsset = await _assetService.AddAssetAsync(asset);
            return CreatedAtAction(nameof(Get), new { id = createdAsset.Id }, createdAsset);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Asset asset)
        {
            if (id != asset.Id)
            {
                return BadRequest();
            }
            await _assetService.UpdateAssetAsync(asset);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _assetService.DeleteAssetAsync(id);
            return NoContent();
        }
    }
}

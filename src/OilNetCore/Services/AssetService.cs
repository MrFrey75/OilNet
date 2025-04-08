using Microsoft.EntityFrameworkCore;
using OilNetCore.Data;
using OilNetCore.Models;

namespace OilNetCore.Services;

public class AssetService
{
    private readonly CoreDbContext _context;

    public AssetService(CoreDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Asset>> GetAllAssetsAsync()
    {
        return await _context.Assets
            .Where(x => !x.IsDeleted)
            .ToListAsync();
    }
    
    public async Task<Asset?> GetAssetByIdAsync(Guid uid)
    {
        return await _context.Assets
            .FirstOrDefaultAsync(x => x.Uid == uid && !x.IsDeleted);
    }
    
    public async Task<Asset> CreateAssetAsync(Asset asset)
    {
        _context.Assets.Add(asset);
        await _context.SaveChangesAsync();
        return asset;
    }
    
    public async Task<Asset?> UpdateAssetAsync(Asset asset)
    {
        var existingAsset = await _context.Assets
            .FirstOrDefaultAsync(x => x.Uid == asset.Uid && !x.IsDeleted);

        if (existingAsset == null) return null;

        existingAsset.AssetType = asset.AssetType;

        await _context.SaveChangesAsync();
        return existingAsset;
    }
    
    public async Task<bool> DeleteAssetAsync(Guid uid)
    {
        var asset = await _context.Assets.FirstOrDefaultAsync(x => x.Uid == uid);
        if (asset == null) return false;

        asset.IsDeleted = true;
        await _context.SaveChangesAsync();
        return true;
    }
    
        
    
    
}
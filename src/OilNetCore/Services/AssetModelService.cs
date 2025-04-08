using Microsoft.EntityFrameworkCore;
using OilNetCore.Data;
using OilNetCore.Models;

namespace OilNetCore.Services;

public class AssetModelService
{
    private readonly CoreDbContext _context;

    public AssetModelService(CoreDbContext context)
    {
        _context = context;
    }

    // Get all asset models that are not deleted
    public async Task<List<AssetModel>> GetAllAssetModelsAsync()
    {
        return await _context.AssetModels
            .Where(x => !x.IsDeleted)
            .ToListAsync();
    }

    // Get asset model by unique ID
    public async Task<AssetModel?> GetAssetModelByIdAsync(Guid uid)
    {
        return await _context.AssetModels
            .FirstOrDefaultAsync(x => x.Uid == uid && !x.IsDeleted);
    }

    // Create a new asset model
    public async Task<AssetModel> CreateAssetModelAsync(AssetModel assetModel)
    {
        _context.AssetModels.Add(assetModel);
        await _context.SaveChangesAsync();
        return assetModel;
    }

    // Update existing asset model
    public async Task<AssetModel?> UpdateAssetModelAsync(AssetModel assetModel)
    {
        var model = await _context.AssetModels
            .FirstOrDefaultAsync(x => x.Uid == assetModel.Uid && !x.IsDeleted);

        if (model == null) return null;

        model.Name = assetModel.Name;
        model.Description = assetModel.Description;
        model.Manufacturer = assetModel.Manufacturer;
        model.ModelNumber = assetModel.ModelNumber;
        model.AssetType = assetModel.AssetType;

        await _context.SaveChangesAsync();
        return model;
    }

    // Soft delete asset model by ID
    public async Task<bool> DeleteAssetModelAsync(Guid uid)
    {
        var assetModel = await _context.AssetModels.FirstOrDefaultAsync(x => x.Uid == uid);
        if (assetModel == null) return false;

        assetModel.IsDeleted = true;
        await _context.SaveChangesAsync();
        return true;
    }
}
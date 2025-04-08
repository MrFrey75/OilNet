using OilNetCore.Enumerations;

namespace OilNetCore.Models;

public class Asset : EntityBase
{
    protected Asset()
    {
        
    }

    private AssetModel AssetModel { get; set; } = new AssetModel();
    public AssetStatus Status { get; set; } = AssetStatus.Unknown;
    public string AssetNumber { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public AssetType AssetType
    {
        get => AssetModel.AssetType;
        set => AssetModel.AssetType = value;
    }
    
    public string Name => AssetModel.Name;
    public string Description => AssetModel.Description;
    public string Manufacturer => AssetModel.Manufacturer;
    public string ModelNumber => AssetModel.ModelNumber;

    
    
}
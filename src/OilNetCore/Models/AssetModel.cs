using OilNetCore.Enumerations;

namespace OilNetCore.Models;

public class AssetModel : EntityBase
{
    public AssetModel()
    {
        
    }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public string ModelNumber { get; set; } = string.Empty;
    public AssetType AssetType { get; set; } = AssetType.Unknown;
}
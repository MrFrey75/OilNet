using OilNetCore.Enumerations;

namespace OilNetCore.Models;

public class Monitor : Asset
{
    public Monitor()
    {
        AssetType = AssetType.Monitor;
    }
    
    public string Resolution { get; set; } = string.Empty;
}
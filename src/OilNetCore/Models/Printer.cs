using OilNetCore.Enumerations;

namespace OilNetCore.Models;

public class Printer : Asset
{
    public Printer()
    {
        AssetType = AssetType.Printer;
    }
    
    public string PrinterType { get; set; } = string.Empty;
}
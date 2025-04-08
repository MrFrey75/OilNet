using OilNetCore.Enumerations;

namespace OilNetCore.Models;

public abstract class CpuDevice : Asset
{
    protected CpuDevice()
    {
        AssetType = AssetType.Computer;
    }
    
    public string OperatingSystem { get; set; } = string.Empty;
}

public class Server : CpuDevice
{
    public Server()
    {
        
    }
    
    public string RackSize { get; set; } = string.Empty;
}


public class Desktop : CpuDevice
{
    public Desktop()
    {
        
    }
    
    public string FormFactor { get; set; } = string.Empty;
 
}

public class Laptop : CpuDevice
{
    public Laptop()
    {
        
    }
    
    public string DisplaySize { get; set; } = string.Empty;
}

public class Tablet : CpuDevice
{
    public Tablet()
    {
        
    }
    
    public string ScreenSize { get; set; } = string.Empty;
}
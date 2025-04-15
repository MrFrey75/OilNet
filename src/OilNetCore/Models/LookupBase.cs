using System.ComponentModel.DataAnnotations;

namespace OilNetCore.Models;

public abstract class LookupBase
{
    protected LookupBase()
    {
        
    }
    [Key]
    public int Oid { get; set; } = 0;
    public bool IsDeleted { get; set; } = false;
    public string Title { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
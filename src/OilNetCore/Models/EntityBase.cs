using System.ComponentModel.DataAnnotations;

namespace OilNetCore.Models;

public class EntityBase
{
    protected EntityBase()
    {
        
    }
    [Key]
    public Guid Uid { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;
}
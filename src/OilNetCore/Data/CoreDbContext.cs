using Microsoft.EntityFrameworkCore;
using OilNetCore.Models;

namespace OilNetCore.Data;

public class CoreDbContext : DbContext
{
    public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options) { }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);



        // Inheritance: TPH (Table-per-Hierarchy) by default — override if needed
        // You could use .HasDiscriminator<string>("AssetType") if you want to store them in a single table.

        // Ignore non-persisted Asset.AssetModel if needed (not directly mapped)

    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        foreach (var entry in ChangeTracker.Entries<LookupBase>())
        {
            if (entry.Entity.Oid == 0)
            {
                entry.State = EntityState.Added;
            }
            switch (entry)
            {
                case { State: EntityState.Modified }:
                    entry.Entity.UpdatedAt = DateTime.Now;
                    break;
                case { State: EntityState.Added }:
                    entry.Entity.CreatedAt = DateTime.Now;
                    entry.Entity.UpdatedAt = DateTime.Now;
                    break;
                case { State: EntityState.Detached }:
                    entry.State = EntityState.Unchanged;
                    break;
                case { State: EntityState.Deleted }:
                    entry.State = EntityState.Modified;
                    entry.Entity.UpdatedAt = DateTime.Now;
                    entry.Entity.IsDeleted = true;
                    break;
                case { State: EntityState.Unchanged }:
                    break;
            }
        }
        
        // Set the IsDeleted property to true for soft delete
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {

            switch (entry)
            {
                case { State: EntityState.Modified }:
                    entry.Entity.UpdatedAt = DateTime.Now;
                    break;
                case { State: EntityState.Added }:
                    entry.Entity.CreatedAt = DateTime.Now;
                    entry.Entity.UpdatedAt = DateTime.Now;
                    break;
                case { State: EntityState.Detached }:
                    entry.State = EntityState.Unchanged;
                    break;
                case { State: EntityState.Deleted }:
                    entry.State = EntityState.Modified;
                    entry.Entity.UpdatedAt = DateTime.Now;
                    entry.Entity.IsDeleted = true;
                    break;
                case { State: EntityState.Unchanged }:
                    break;
            }
            
        }
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }
}
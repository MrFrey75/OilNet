using Microsoft.EntityFrameworkCore;
using OilNetCore.Models;
using Monitor = OilNetCore.Models.Monitor;

namespace OilNetCore.Data;

public class CoreDbContext : DbContext
{
    public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options) { }

    public DbSet<Asset> Assets { get; set; }
    public DbSet<AssetModel> AssetModels { get; set; }
    public DbSet<Monitor> Monitors { get; set; }
    public DbSet<Printer> Printers { get; set; }
    public DbSet<Server> Servers { get; set; }
    public DbSet<Desktop> Desktops { get; set; }
    public DbSet<Laptop> Laptops { get; set; }
    public DbSet<Tablet> Tablets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Table mappings (optional but nice)
        modelBuilder.Entity<Asset>().ToTable("Assets");
        modelBuilder.Entity<AssetModel>().ToTable("AssetModels");
        modelBuilder.Entity<Monitor>().ToTable("Monitors");
        modelBuilder.Entity<Printer>().ToTable("Printers");
        modelBuilder.Entity<Server>().ToTable("Servers");
        modelBuilder.Entity<Desktop>().ToTable("Desktops");
        modelBuilder.Entity<Laptop>().ToTable("Laptops");
        modelBuilder.Entity<Tablet>().ToTable("Tablets");

        // Inheritance: TPH (Table-per-Hierarchy) by default — override if needed
        // You could use .HasDiscriminator<string>("AssetType") if you want to store them in a single table.

        // Ignore non-persisted Asset.AssetModel if needed (not directly mapped)
        modelBuilder.Entity<Asset>()
            .Ignore(a => a.Name)
            .Ignore(a => a.Description)
            .Ignore(a => a.Manufacturer)
            .Ignore(a => a.ModelNumber)
            .Ignore(a => a.AssetType);
    }
}
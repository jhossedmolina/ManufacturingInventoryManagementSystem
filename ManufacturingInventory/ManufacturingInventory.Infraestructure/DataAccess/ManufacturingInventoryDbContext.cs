using ManufacturingInventory.Domain.Entities;
using ManufacturingInventory.Infraestructure.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ManufacturingInventory.Infraestructure.DataAccess;

public partial class ManufacturingInventoryDbContext : DbContext
{
    public ManufacturingInventoryDbContext()
    {
    }

    public ManufacturingInventoryDbContext(DbContextOptions<ManufacturingInventoryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationUserConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

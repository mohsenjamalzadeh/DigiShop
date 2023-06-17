using InventoryManagement.Domain.ColorAgg;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Domain.SizeAgg;
using InventoryManagement.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.EfCore
{
    public class InventoryContext:DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> option):base(option)
        {
            
        }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly=typeof(InventoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
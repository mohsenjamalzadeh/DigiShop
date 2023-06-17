using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace InventoryManagement.Infrastructure.EfCore.Mapping
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventories");
            builder.HasKey(x => x.Id);

            builder.OwnsMany(p => p.Operations, modelbuilder =>
            {
                modelbuilder.ToTable("InventoryOperations");
                modelbuilder.HasKey(x => x.Id);
                modelbuilder.Property(p => p.Describtion).HasMaxLength(1000);

                modelbuilder.WithOwner(p => p.Inventory).HasForeignKey(p => p.InventoryId);
            });

            builder.OwnsMany(p => p.productVariants, modelbuilder =>
            {
                modelbuilder.ToTable("ProductsVarient");
                modelbuilder.HasKey(x => x.Id);

                modelbuilder.Property(p=>p.ColorId).IsRequired(false);
                modelbuilder.Property(p=>p.SizeId).IsRequired(false);

                modelbuilder.WithOwner(p=>p.Inventory).HasForeignKey(p=>p.InventoryId);
            });
        }
    }
}

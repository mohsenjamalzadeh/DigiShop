using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPictures");

            builder.HasKey(x => x.Id);
            builder.Property(p => p.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(p => p.PictureAlt).HasMaxLength(250).IsRequired();
            builder.Property(p => p.PictureTitle).HasMaxLength(250).IsRequired();
            builder.Property(p => p.CreationDate).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();

            builder.HasOne(p => p.Product).WithMany(p=>p.ProductPictures).HasForeignKey(p=>p.ProductId);
        }
    }
}

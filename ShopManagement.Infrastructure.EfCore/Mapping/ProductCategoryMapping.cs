using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class ProductCategoryMapping:IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");
            builder.HasKey(p => p.Id);

            builder.Property(p=>p.Name).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.PictureAlt).HasMaxLength(255);
            builder.Property(p => p.PictureTitle).HasMaxLength(255);
            builder.Property(p => p.Picture).HasMaxLength(1000);
            builder.Property(p => p.KeyWords).HasMaxLength(80).IsRequired();
            builder.Property(p => p.CreationDate).IsRequired();
            builder.Property(p => p.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Slug).HasMaxLength(300).IsRequired();

        }
    }
}

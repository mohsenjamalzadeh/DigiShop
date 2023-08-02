using DiscountManagement.Domain.CustomerDiscount;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagement.Infrastructure.EfCore.Mappings
{
    public class CustomerDiscountMapping : IEntityTypeConfiguration<CustomerDiscount>
    {
        public void Configure(EntityTypeBuilder<CustomerDiscount> builder)
        {
            builder.ToTable("CustomerDiscounts");
            builder.HasKey(x => x.Id);
            builder.Property(p=>p.StartDate).IsRequired();  
            builder.Property(p=>p.EndDate).IsRequired();  
            builder.Property(p=>p.Description).HasMaxLength(300);
        }
    }
}

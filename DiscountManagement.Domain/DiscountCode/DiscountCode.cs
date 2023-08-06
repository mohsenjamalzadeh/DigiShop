using _01_framework.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscountManagement.Domain.DiscountCode
{
    public class DiscountCode : EntityBase
    {
        public string Name { get; set; }
        public bool UsePercentage { get; set; }
        public int DsicountPercentage { get; set; }
        public double DiscountAmount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public string CouponCode { get; set; }
        public int NumberOfUses { get; set; }
        public long? UserId { get; set; }
        public long? ProductId { get; set; }
        public long? CategoryId { get; set; }

        public int DiscountTypeId { get; set; }
        
        [NotMapped]
        public DiscountType DiscountType
        {
            get => (DiscountType)DiscountTypeId;
            set => DiscountTypeId = (int)value;
        }




    }


    public enum DiscountType
    {
        AssignedToProduct = 1,
        AssignedToCategory = 2,
        AssignedToToUser = 3,


    }

   

}

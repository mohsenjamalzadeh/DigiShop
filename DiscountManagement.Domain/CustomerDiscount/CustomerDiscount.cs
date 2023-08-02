using _01_framework.Domain;

namespace DiscountManagement.Domain.CustomerDiscount
{
    public class CustomerDiscount : EntityBase
    {
        public long ProductId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool UsePercentDiscount { get; private set; }
        public int DiscountRate { get; private set; } = 0;
        public double DiscountPrice { get; private set; } = 0;
        public bool IsRemove { get; private set; }
        public string Description { get; private set; }

        public CustomerDiscount(long productId, DateTime startDate, DateTime endDate, bool usePercentDiscount, int discountRate, double discountPrice, string description)
        {
            ProductId = productId;
            StartDate = startDate;
            EndDate = endDate;
            UsePercentDiscount = usePercentDiscount;
            DiscountRate = discountRate;
            DiscountPrice = discountPrice;
            IsRemove = false;
            Description = description;
        }

        public void Edit(long productId, DateTime startDate, DateTime endDate, bool usePercentDiscount, int discountRate, double discountPrice, string description)
        {
            ProductId = productId;
            StartDate = startDate;
            EndDate = endDate;
            UsePercentDiscount = usePercentDiscount;
            DiscountRate = discountRate;
            DiscountPrice = discountPrice;
            Description = description;
            base.SetModefiedDate();
        }

        public void Delete() => IsRemove = true;
        public void Active() => IsRemove = false;
    }
}

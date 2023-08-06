namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public class CustomerDiscountViewModel
    {
        public long Id { get; set; }
        public string CreationDate { get; set; }
        public string ModifiedDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsRemove { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; }
        public bool UsePercentDiscount { get; set; }
        public int DiscountRate { get; set; }
        public double DiscountPrice { get; set; }

        public DateTime StartDateSe { get; set; }
        public DateTime EndDateSe { get; set; }
    }
}

namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public class CustomerDiscountSearchModel
    {

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }   
}

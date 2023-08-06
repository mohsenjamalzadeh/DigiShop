namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public class EditDiscount : DefineDiscount
    {
        public long Id { get; set; }
        public long ProductId { get; set; }

    }
}

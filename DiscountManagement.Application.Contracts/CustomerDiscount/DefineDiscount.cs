using _01_framework.Application;

namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public class DefineDiscount
    {
        public List<long> ProductsId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool UsePercentDiscount { get; set; }
        public int DiscountRate { get; set; } = 0;
        public double DiscountPrice { get; set; } = 0;
        public string Description { get; set; }


    }

    public class EditDiscount : DefineDiscount
    {
        public long Id { get; set; }
        public long ProductId { get; set; }

    }

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

    public class CustomerDiscountSearchModel
    {

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }

    public interface ICustomerDiscountApplication
    {
        OperationResult DefineCustomerDiscount(DefineDiscount command);
        OperationResult EditCustomerDiscount(EditDiscount command);
        OperationResult ActiveDiscount(long id);
        OperationResult DeActiveDiscount(long id);
        List<CustomerDiscountViewModel> GetAll(CustomerDiscountSearchModel searchModel);
        EditDiscount GetDetails(long id);

    }
}

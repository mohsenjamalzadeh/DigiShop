using _01_framework.Application;

namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
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

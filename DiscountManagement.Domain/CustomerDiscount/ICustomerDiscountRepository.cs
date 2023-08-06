using _01_framework.Application;
using _01_framework.Domain;
using DiscountManagement.Application.Contracts.CustomerDiscount;


namespace DiscountManagement.Domain.CustomerDiscount
{
    public interface ICustomerDiscountRepository : IRepository<long, CustomerDiscount>
    {
        List<CustomerDiscountViewModel> GetAll(CustomerDiscountSearchModel searchModel);
        EditDiscount GetDetails(long id);

    }
}

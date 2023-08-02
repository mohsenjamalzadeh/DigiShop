using DiscountManagement.Application.Contracts.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administrator.Pages.Discount.CustomerDiscount
{
    public class IndexModel : PageModel
    {

        private readonly ICustomerDiscountApplication _customerDiscountApplication;

        public CustomerDiscountSearchModel searchModel { get; set; }
        public List<CustomerDiscountViewModel> CustomerDiscounts { get; set; }

        public IndexModel(ICustomerDiscountApplication customerDiscountApplication)
        {
            _customerDiscountApplication=customerDiscountApplication;
            CustomerDiscounts=new List<CustomerDiscountViewModel>();
        }
        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            CustomerDiscounts=_customerDiscountApplication.GetAll(searchModel);
        }
    }
}

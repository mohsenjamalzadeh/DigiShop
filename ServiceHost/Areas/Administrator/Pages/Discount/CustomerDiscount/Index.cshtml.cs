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


        public IActionResult OnGetActive(long id)
        {
            var result=_customerDiscountApplication.ActiveDiscount(id);
            return RedirectToPage("./Index");
        }

         public IActionResult OnGetDeActive(long id)
        {
            var result=_customerDiscountApplication.DeActiveDiscount(id);
            return RedirectToPage("./Index");
        }
    }
}

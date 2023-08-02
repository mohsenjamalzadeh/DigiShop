using DiscountManagement.Application.Contracts.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administrator.Pages.Discount.CustomerDiscount
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerDiscountApplication _customerDiscountApplication;

        [BindProperty]
        public DefineDiscount  Define { get; set; }

        public CreateModel(ICustomerDiscountApplication customerDiscountApplication)
        {
            _customerDiscountApplication = customerDiscountApplication;
        
        }

        public void OnGet()
        {
        }


        public IActionResult OnPostDefine()
        {

            var result=_customerDiscountApplication.DefineCustomerDiscount(Define);
           return RedirectToPage("./Index");
        }
    }
}

using DiscountManagement.Application.Contracts.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administrator.Pages.Discount.CustomerDiscount
{
    public class EditModel : PageModel
    {
        private readonly ICustomerDiscountApplication _customerDiscountApplication;
      
        public EditModel(ICustomerDiscountApplication customerDiscountApplication)
        {
            _customerDiscountApplication = customerDiscountApplication;
        }

        [BindProperty]
        public EditDiscount Edit { get; set; }
        public void OnGet(long id,string name)
        {
            ViewData["name"] = name;
            Edit=_customerDiscountApplication.GetDetails(id);
            
        }


        public IActionResult OnPostEdit()
        {
            var result=_customerDiscountApplication.EditCustomerDiscount(Edit);
            return RedirectToPage("./Index");
        }
    }
}

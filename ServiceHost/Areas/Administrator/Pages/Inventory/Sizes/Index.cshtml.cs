using InventoryManagement.Application.Constract.Sizes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administrator.Pages.Inventory.Sizes
{
    public class IndexModel : PageModel
    {
        private readonly ISizeApplication _sizeApplication;

        public List<SizeViewModel> Sizes { get; set; }
        public IndexModel(ISizeApplication sizeApplication)
        {
            _sizeApplication = sizeApplication;
        }

        public void OnGet()
        {
            Sizes = _sizeApplication.GetAll();
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }

        public IActionResult OnPostCreate(CreateSize command)
        {
            var result = _sizeApplication.CreateSize(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var size = _sizeApplication.GetDetails(id);
            return Partial("./Edit",size);
        }

        public IActionResult OnPostEdit(EditSize command)
        {
            var result=_sizeApplication.EditSize(command);
            return new JsonResult(result);
        }

    }
}

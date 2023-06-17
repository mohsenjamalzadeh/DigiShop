using InventoryManagement.Application.Constract.Color;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administrator.Pages.Inventory.Colors
{
    public class IndexModel : PageModel
    {
        private readonly IColorApplication _colorApplication;

        public List<ColorViewModel> Colors { get; set; }
        public IndexModel(IColorApplication colorApplication)
        {
            _colorApplication = colorApplication;
        }

        public void OnGet()
        {
            Colors = _colorApplication.GetAll();
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }

        public IActionResult OnPostCreate(CreateColor command)
        {
            var result = _colorApplication.CreateColor(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(int id)
        {
            var color = _colorApplication.GetDetails(id);
            return Partial("./Edit",color);
        }

        public IActionResult OnPostEdit(EditColor command)
        {
            var result=_colorApplication.EditColor(command);
            return new JsonResult(result);
        }

    }
}

using InventoryManagement.Application.Constract.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administrator.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        private readonly IInventoryApplication _inventoryApplication;
        private readonly IProductApplication _productApplication;
        public List<InventoryViewModel> Inventories { get; set; }
        public InventorySearchModel searchModel { get; set; }
        public SelectList  Products { get; set; }
        public IndexModel(IInventoryApplication inventoryApplication, IProductApplication productApplication)
        {
            _inventoryApplication = inventoryApplication;
            _productApplication = productApplication;
        }

        public void OnGet(InventorySearchModel searchModel)
        {
            Products=new SelectList(_productApplication.GetAll(),"Id","Name");
            Inventories = _inventoryApplication.GetAll(searchModel);

        }


        public IActionResult OnGetCreate()
        {
            var createInventory = new CreateInventory()
            {
                Products = _productApplication.GetAll()
            };

            return Partial("./Create", createInventory);
        }

        public IActionResult OnPostCreate(CreateInventory command)
        {
            var result = _inventoryApplication.AddInventory(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var inventory = _inventoryApplication.GetDetails(id);
            inventory.Products = _productApplication.GetAll();
            return Partial("./Edit", inventory);
        }

        public IActionResult OnPostEdit(UpdateInventory command)
        {

            var result = _inventoryApplication.EditInventory(command);
            return new JsonResult(result);

        }


    }
}

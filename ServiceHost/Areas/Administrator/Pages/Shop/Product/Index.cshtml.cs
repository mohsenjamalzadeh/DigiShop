using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administrator.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public SelectList Categories { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public SearchModel searchModel { get; set; }

        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
            _productApplication = productApplication;
            Products=new List<ProductViewModel>();
        }

        public void OnGet(SearchModel searchModel)
        {
            Categories = new SelectList(_productCategoryApplication.GetCategories(), "Id", "Name");
            Products = _productApplication.GetAll(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct
            {
                Categories = _productCategoryApplication.GetCategories()
            };

            return Partial("./Create", command);
        }

        public IActionResult OnPostCreate(CreateProduct command)
        {
            var result = _productApplication.CreateProduct(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var product = _productApplication.GetDetails(id);
            product.Categories=_productCategoryApplication.GetCategories();
            return Partial("./Edit", product);
        }

        public IActionResult OnPostEdit(EditProduct command)
        {
            var result = _productApplication.EditProduct(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetActive(long id)
        {
            var result = _productApplication.Active(id);
            return Redirect("./Index");
        }

        public IActionResult OnGetDeActive(long id)
        {
            var result = _productApplication.DeActive(id);
            return Redirect("./Index");

        }
    }
}

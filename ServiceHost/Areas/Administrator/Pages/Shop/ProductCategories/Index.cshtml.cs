using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ServiceHost.Areas.Administrator.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {
        private readonly IProductCategoryApplication _productCategoryApplication;
        public List<ProductCategoryViewmodel> ProductCategories { get; set; }
        public ProductCategorySearchModel searchModel { get; set; }

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ProductCategories = _productCategoryApplication.GetAll(searchModel);
        }


        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }

        public IActionResult OnPostCreate(CreateProductCategory command)
        {
            var result=_productCategoryApplication.CreateProductCategory(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productCategory=_productCategoryApplication.GetDetails(id);
            return Partial("./Edit", productCategory);
        }

        public IActionResult OnPostEdit(EditProductCategory command)
        {
            var result=_productCategoryApplication.EditProductCategory(command);
            return new JsonResult(result);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ServiceHost.Areas.Administrator.Pages.Shop.ProductPicture
{
    public class IndexModel : PageModel
    {
        private readonly IProductPictureApplication _productPictureApplication;
        private readonly IProductApplication _productApplication;

        public List<ProductPictureViewModel> ProductPictures { get; set; }
        public ProductViewModel Product { get; set; }


        public long ProductId { get; set; }

        public IndexModel(IProductPictureApplication productPictureApplication, IProductApplication productApplication)
        {
            _productPictureApplication = productPictureApplication;
            _productApplication = productApplication;
            ProductPictures = new List<ProductPictureViewModel>();


        }

        public void OnGet(long id)
        {
            Product = _productApplication.GetProductBy(id);
            ProductPictures = _productPictureApplication.GetProductPictures(id);
        }


        public IActionResult OnGetCreate(long id)
        {

            var command = new CreateProductPicture
            {
                ProductId = id
            };
            return Partial("./Create", command);
        }

        public IActionResult OnPostCreate(CreateProductPicture command)
        {
            var result = _productPictureApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productPicture = _productPictureApplication.GetDetails(id);
            return Partial("./Edit", productPicture);
        }

        public IActionResult OnPostEdit(EditProductPicture command)
        {
            var result = _productPictureApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetActive(long id, long productId)
        {
            _productPictureApplication.Active(id);
            return RedirectToPage("./Index", new { id = productId });
        }

        public IActionResult OnGetDeActive(long id, long productId)
        {
            _productPictureApplication.DeActive(id);
            return RedirectToPage("./Index", new { id = productId });
        }
    }
}

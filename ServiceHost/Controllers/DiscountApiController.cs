using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountApiController : ControllerBase
    {

        private readonly IProductApplication _productApplication;

        public DiscountApiController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        [HttpGet]
        [Route("SearchProducts")]
        public async Task<IActionResult> SearchProducts(string? term)
        {
            return Ok(_productApplication.GetProductsforDisCounts(term));
        }
    }
}

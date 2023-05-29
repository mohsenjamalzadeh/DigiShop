using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.Product
{
    public class EditProduct : CreateProduct
    {
        public long Id { get; set; }
        public IFormFile? Picture { get; set; }

    }
}

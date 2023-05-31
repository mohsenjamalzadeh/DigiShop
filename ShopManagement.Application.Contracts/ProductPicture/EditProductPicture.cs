using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class EditProductPicture : CreateProductPicture
    {
        public long Id { get; set; }
        public IFormFile? Picture { get; set; }
    }

}

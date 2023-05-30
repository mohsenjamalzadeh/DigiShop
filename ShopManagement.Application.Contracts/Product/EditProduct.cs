using _01_framework.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.Product
{
    public class EditProduct : CreateProduct
    {
        public long Id { get; set; }

        [FileExtentionAttr(new[] { ".jpg", ".jpg", ".png" }, ErrorMessage = "The imported file format is not correct ")]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = "The file size exceeds the limit")]
        public IFormFile? Picture { get; set; }

    }
}

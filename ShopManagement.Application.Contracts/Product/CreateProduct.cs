using _01_framework.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contracts.ProductCategory;
using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;

namespace ShopManagement.Application.Contracts.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Code { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Description { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get; set; }

        [FileExtentionAttr(new[] { ".jpg", ".jpg", ".png" }, ErrorMessage = "The imported file format is not correct ")]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = "The file size exceeds the limit")]
        public IFormFile Picture { get; set; }


        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWords { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductCategoryId { get; set; }
        public List<ProductCategoryViewmodel> Categories { get; set; }
    }
}

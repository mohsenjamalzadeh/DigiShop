using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.ProductCategory;

public class EditProductCategory : CreateProductCategory
{
    public long Id { get; set; }
    public IFormFile? Picture { get; set; }

}
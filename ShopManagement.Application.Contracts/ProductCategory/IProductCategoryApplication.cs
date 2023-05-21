

using _01_framework.Application;

namespace ShopManagement.Application.Contracts.ProductCategory;

public interface IProductCategoryApplication
{
    OperationResult CreateProductCategory(CreateProductCategory command);
    OperationResult EditProductCategory(EditProductCategory command);
    EditProductCategory GetDetails(long id);
    List<ProductCategoryViewmodel> GetAll(ProductCategorySearchModel searchModel);
}
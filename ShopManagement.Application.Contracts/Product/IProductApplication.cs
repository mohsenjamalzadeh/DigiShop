using _01_framework.Application;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        OperationResult CreateProduct(CreateProduct command);
        OperationResult EditProduct(EditProduct command);

        ProductViewModel GetProductBy(long id);
        OperationResult Active(long id);
        OperationResult DeActive(long id);
        EditProduct GetDetails(long id);
        List<ProductViewModel> GetAll(SearchModel searchModel);
        List<ProductViewModel> GetAll();
        List<ProductViewModel> GetProductsforDisCounts(string term);
        
    }
}

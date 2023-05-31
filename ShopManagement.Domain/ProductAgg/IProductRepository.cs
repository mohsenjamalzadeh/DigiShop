using _01_framework.Domain;
using ShopManagement.Application.Contracts.Product;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<long, Product>
    {
        EditProduct GetDetails(long id);
        ProductViewModel GetProductBy(long id);
        List<ProductViewModel> GetAll(SearchModel searchModel);
        (long id, string slug, string categorySlug) ProductAndCategory(long id);
    }
}

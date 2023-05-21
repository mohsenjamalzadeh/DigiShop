using _01_framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult CreateProductCategory(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if (_productCategoryRepository.IsExist(p => p.Name == command.Name))
                return operation.Failed("");

            var slug = command.Slug.Slugify();
            var productCategory = new ProductCategory(command.Name, command.Description, command.PictureAlt,
                command.PictureTitle
                , command.Picture, command.KeyWords, command.MetaDescription, slug);
            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChanges();
            return operation.IsSucssed();
        }

        public OperationResult EditProductCategory(EditProductCategory command)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.GetBy(command.Id);

            if (productCategory == null)
                return operation.Failed("");

            if (_productCategoryRepository.IsExist(p => p.Name == command.Name && p.Id != command.Id))
                return operation.Failed("");

            var slug = command.Slug.Slugify();

            productCategory.Edit(command.Name, command.Description, command.PictureAlt,
                command.PictureTitle
                , command.Picture, command.KeyWords, command.MetaDescription, slug);

            _productCategoryRepository.SaveChanges();
            return operation.IsSucssed();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewmodel> GetAll(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.GetAll(searchModel);
        }
    }
}
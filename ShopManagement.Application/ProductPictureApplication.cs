using _01_framework.Application;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IProductRepository _productRepository;
        private readonly IProductPictureRepository _productPictureRepository;
        public ProductPictureApplication(IFileUploader fileUploader, IProductPictureRepository productPictureRepository
            , IProductRepository productRepository)
        {
            _fileUploader = fileUploader;
            _productRepository = productRepository;
            _productPictureRepository = productPictureRepository;
        }

        public OperationResult Active(long id)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.GetBy(id);
            if (productPicture is null) return operation.Failed(ResultMessage.IsNotExistRecord);
            productPicture.Active();
            _productPictureRepository.SaveChanges();

            return operation.IsSucssed();
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var operstion = new OperationResult();

            var productAndCategory = _productRepository.ProductAndCategory(command.ProductId);
            var path = $"{productAndCategory.categorySlug}//{productAndCategory.slug}";
            foreach (var item in command.Picture)
            {
                string picture = _fileUploader.Upload(item, path);
                var productPicture = new ProductPicture(picture, command.PictureAlt, command.PictureTitle, command.ProductId);
                _productPictureRepository.Create(productPicture);
                _productPictureRepository.SaveChanges();
            }


            return operstion.IsSucssed();

        }

        public OperationResult DeActive(long id)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.GetBy(id);
            if (productPicture is null) return operation.Failed(ResultMessage.IsNotExistRecord);
            productPicture.DeActive();
            _productPictureRepository.SaveChanges();

            return operation.IsSucssed();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();

            var productPicture = _productPictureRepository.GetBy(command.Id);
            if (productPicture is null) return operation.Failed(ResultMessage.IsNotExistRecord);

        
                var productAndCategory = _productRepository.ProductAndCategory(command.ProductId);
                var path = $"{productAndCategory.categorySlug}//{productAndCategory.slug}";
       

            string picture = _fileUploader.Upload(command.Picture, path);

            productPicture.Edit(picture, command.PictureAlt, command.PictureTitle, command.ProductId);
            _productPictureRepository.SaveChanges();

            return operation.IsSucssed();
        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public List<ProductPictureViewModel> GetProductPictures(long id)
        {
            return _productPictureRepository.GetProductPictures(id);
        }
    }
}

using _01_framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Active(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.GetBy(id);

            if (product is null)
                return operation.Failed(ResultMessage.IsNotExistRecord);
            

            product.Active();
            _productRepository.SaveChanges();

            return operation.IsSucssed();
        }

        public OperationResult CreateProduct(CreateProduct command)
        {
            var operation = new OperationResult();

            if(_productRepository.IsExist(p=>p.Name==command.Name  ))
                return operation.Failed(ResultMessage.IsDoblicated);

            var slug=command.Slug.Slugify();

            var product=new Product(command.Name,command.Code,command.Description,command.PictureAlt,command.PictureTitle
                ,command.Picture,slug,command.MetaDescription,command.KeyWords,command.ProductCategoryId);
            _productRepository.Create(product);
            _productRepository.SaveChanges();

            return operation.IsSucssed();
        }

        public OperationResult DeActive(long id)
        {

            var operation = new OperationResult();
            var product = _productRepository.GetBy(id);

            if (product is null)
            {
                return operation.Failed(ResultMessage.IsNotExistRecord);
            }

            product.DeActive();
            _productRepository.SaveChanges();

            return operation.IsSucssed();
        }

        public OperationResult EditProduct(EditProduct command)
        {
            var operation=new OperationResult();

            var product=_productRepository.GetBy(command.Id);

            if(product is null )
                return operation.Failed(ResultMessage.IsNotExistRecord);

            if(_productRepository.IsExist(p=>p.Name == command.Name && p.Id != command.Id))
                return operation.Failed(ResultMessage.IsDoblicated);

            var slug = command.Slug.Slugify();
            product.Edit(command.Name,command.Code,command.Description,command.PictureAlt,command.PictureTitle
                ,command.Picture,slug,command.MetaDescription,command.KeyWords,command.ProductCategoryId);
            _productRepository.SaveChanges();

            return operation.IsSucssed();
        }

        public List<ProductViewModel> GetAll(SearchModel searchModel)
        {
            return _productRepository.GetAll(searchModel);
        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }
    }
}

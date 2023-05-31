using _01_framework.Application;
using System.Buffers;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public interface IProductPictureApplication
    {
        OperationResult Create(CreateProductPicture command);
        OperationResult Edit(EditProductPicture command);
        OperationResult Active(long id);
        OperationResult DeActive(long id);
        EditProductPicture GetDetails(long id);
        List<ProductPictureViewModel> GetProductPictures(long id);
        
    }

}

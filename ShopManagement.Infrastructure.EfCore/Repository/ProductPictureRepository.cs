using _01_framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _context;

        public ProductPictureRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProductPicture GetDetails(long id)
        {
            var pruductPicture=_context.ProductPictures.Include(p=>p.Product).Select(p=>new EditProductPicture
            {
                Id=p.Id,
                PictureAlt=p.PictureAlt,
                PictureTitle=p.PictureTitle,
                ProductId=p.Product.Id,
                

            }).FirstOrDefault(p=>p.Id==id);

            return pruductPicture;
        }

        public List<ProductPictureViewModel> GetProductPictures(long id)
        {
            var query=_context.ProductPictures.Select(p=>new ProductPictureViewModel
            {
                Id=p.Id,
                CreationDate=p.CreationDate.ToString("g"),
                ModefiedDate=p.ModefiedDate.ToString("g"),
                IsRemove=p.IsDeleted,
                picture=p.Picture,
                ProductId=p.ProductId
               
            }).Where(p=>p.ProductId==id);

            return query.OrderByDescending(p=>p.Id).AsNoTracking().ToList();
        }
    }
}

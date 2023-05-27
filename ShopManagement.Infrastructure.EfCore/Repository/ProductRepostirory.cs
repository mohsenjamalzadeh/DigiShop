using _01_framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class ProductRepostirory : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ShopContext _context;
        public ProductRepostirory(ShopContext context) : base(context)
        {
            _context = context;
        }

        public List<ProductViewModel> GetAll(SearchModel searchModel)
        {
            var query = _context.Products.Include(p => p.productCategory).Select(p => new ProductViewModel
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                Picture = p.Picture,
                IsDeleted = p.IsDeleted,
                PictureAlt = p.PictureAlt,
                PictureTitle = p.PictureTitle,
                CategoryId = p.ProductCategoryId,
                NameCategory = p.productCategory.Name,
                ModefiedDate = p.ModefiedDate.ToString("g"),
                CreationDate = p.CreationDate.ToString("g"),
                Description = p.Description.Substring(0, 20) + "...",

            });

            if (searchModel.Code is not null)
            {
                query = query.Where(p => p.Code == searchModel.Code);
            }
            if (searchModel.Name is not null)
            {
                query = query.Where(p => p.Name == searchModel.Name);

            }

            if (searchModel.CategoryId is not 0)
            {
                query = query.Where(p => p.CategoryId == searchModel.CategoryId);

            }

            return query.OrderByDescending(p => p.Id).AsNoTracking().ToList();
        }

        public EditProduct GetDetails(long id)
        {
            var product = _context.Products.Select(p => new EditProduct
            {
                Id = p.Id,
                Name = p.Name,
                Slug = p.Slug,
                Code = p.Code,
                Picture = p.Picture,
                KeyWords = p.KeyWords,
                PictureAlt = p.PictureAlt,
                Description = p.Description,
                PictureTitle = p.PictureTitle,
                MetaDescription = p.MetaDescription,
                ProductCategoryId = p.ProductCategoryId,

            }).FirstOrDefault(p => p.Id == id);

            return product;
        }
    }
}

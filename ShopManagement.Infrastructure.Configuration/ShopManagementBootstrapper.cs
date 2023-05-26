using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure.EfCore;
using ShopManagement.Infrastructure.EfCore.Repository;

namespace ShopManagement.Infrastructure.Configuration
{
    public class ShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            service.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();

            service.AddTransient<IProductRepository, ProductRepostirory>();
            service.AddTransient<IProductApplication, ProductApplication>();

            service.AddDbContext<ShopContext>(p => p.UseSqlServer(connectionString));
        }
    }
}

using InventoryManagement.Application;
using InventoryManagement.Application.Constract.Color;
using InventoryManagement.Application.Constract.Inventory;
using InventoryManagement.Application.Constract.Sizes;
using InventoryManagement.Domain.ColorAgg;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Domain.SizeAgg;
using InventoryManagement.Infrastructure.EfCore;
using InventoryManagement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Infrastructure.Configuration
{
    public class InventoryManagementBootstrapper
    {
         public  static void Configure(IServiceCollection services,string connectionstring)
        {
            services.AddTransient<IInventoryApplication, InventoryApplication>();
            services.AddTransient<IInventoryRepository, InventoryRepository>();

            services.AddTransient<IColorApplication, ColorApplication>();
            services.AddTransient<ISizeApplication, SizeApplication>();

            services.AddTransient<IColorRepository, ColorRepository>();
            services.AddTransient<ISizeRepository, SizeRepository>();
          

            services.AddDbContext<InventoryContext>(p=>p.UseSqlServer(connectionstring));
        }
    }
}

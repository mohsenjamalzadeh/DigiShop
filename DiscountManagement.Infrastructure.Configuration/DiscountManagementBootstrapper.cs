using DiscountManagement.Application;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscount;
using DiscountManagement.Infrastructure.EfCore;
using DiscountManagement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountManagement.Infrastructure.Configuration
{
    public class DiscountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services,string connectionstring)
        {
            services.AddTransient<ICustomerDiscountRepository,CustomerDiscountRepository>();
            services.AddTransient<ICustomerDiscountApplication,CustomerDiscountApplication>();


            services.AddDbContext<DiscountContext>(option => option.UseSqlServer(connectionstring));

        }
    }
}
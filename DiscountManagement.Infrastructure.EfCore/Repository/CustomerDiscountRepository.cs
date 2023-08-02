using _01_framework.Application;
using _01_framework.Infrastructure;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscount;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EfCore;

namespace DiscountManagement.Infrastructure.EfCore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _discountContext;
        private readonly ShopContext _shopContext;
        public CustomerDiscountRepository(DiscountContext discountContext,ShopContext shopContext) : base(discountContext)
        {
            _discountContext = discountContext;
            _shopContext=shopContext;
        }



        public List<CustomerDiscountViewModel> GetAll(CustomerDiscountSearchModel searchModel)
        {
            var Products = _shopContext.Products.Select(p => new { Id = p.Id, Name = p.Name }).ToList();
            var query = _discountContext.CustomerDiscounts.Select(p => new CustomerDiscountViewModel
            {
                Id = p.Id,
                ProductId = p.ProductId,
                DiscountPrice = p.DiscountPrice,
                CreationDate = p.CreationDate.ToString("g"),
                ModifiedDate = p.ModefiedDate.ToString("g"),
                StartDate = p.StartDate.ToString("g"),
                EndDate = p.EndDate.ToString("g"),
                IsRemove = p.IsRemove,
                UsePercentDiscount = p.UsePercentDiscount,
                DiscountRate = p.DiscountRate,
                StartDateSe = p.StartDate,
                EndDateSe = p.EndDate,

            });

            if (string.IsNullOrWhiteSpace(searchModel.StartDate.ToString("g")))
            {
                query = query.Where(p => p.StartDateSe > searchModel.StartDate);

            }
            if (string.IsNullOrWhiteSpace(searchModel.EndDate.ToString("g")))
            {
                query = query.Where(p => p.EndDateSe > searchModel.EndDate);

            }
            if (searchModel.IsActive)
            {
                query = query.Where(p => !p.IsRemove);

            }

            var discounts = query.OrderByDescending(p => p.Id).AsNoTracking().ToList();

            discounts.ForEach(discount =>
            discount.Product = Products.FirstOrDefault(p => p.Id == discount.ProductId).Name);

            return discounts;
        }

        public EditDiscount GetDetails(long id)
        {
            var discount=_discountContext.CustomerDiscounts.Select(p=> new EditDiscount
            {

                Id=p.Id,
                ProductId=p.ProductId,
                DiscountRate=p.DiscountRate,
                UsePercentDiscount=p.UsePercentDiscount,
                DiscountPrice=p.DiscountPrice,
                StartDate=p.StartDate,
                EndDate=p.EndDate,


            }).FirstOrDefault(p=>p.Id== id);

            return discount;
        }
    }
}

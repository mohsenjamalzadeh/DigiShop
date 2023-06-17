using _01_framework.Infrastructure;
using InventoryManagement.Application.Constract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EfCore;

namespace InventoryManagement.Infrastructure.EfCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly InventoryContext _inventoryContext;
        private readonly ShopContext _shopContext;
        public InventoryRepository(InventoryContext context, ShopContext shopContext) : base(context)
        {
            _inventoryContext = context;
            _shopContext = shopContext;
        }

        public List<InventoryViewModel> GetAll(InventorySearchModel searchModel)
        {
            var products = _shopContext.Products.Select(p => new { p.Id, p.Name });
            var query = _inventoryContext.Inventories.Select(p => new InventoryViewModel
            {
                Id = p.Id,
                ProductId = p.ProductId,
                CurrentCount = p.CurrentCountInventory(),
                Instock = p.InStock,
                CreationDate = p.CreationDate.ToString("g"),
                ModifiedDate = p.ModefiedDate.ToString("g")

            });

            if (searchModel.ProductId > 0)
            {
                query = query.Where(p => p.ProductId == searchModel.ProductId);
            }

            if (searchModel.InStock)
            {
                query = query.Where(p => p.Instock == false);
            }

            var inventory = query.OrderByDescending(p => p.Id).AsNoTracking().ToList();

            inventory.ForEach(x => x.Product = products.FirstOrDefault(p => p.Id == x.ProductId).Name);

            return inventory;
        }

        public UpdateInventory GetDetails(long inventoryId)
        {
            var query = _inventoryContext.Inventories.Select(p => new UpdateInventory
            {
                Id = p.Id,
                ProductId = p.ProductId,
            }).FirstOrDefault(p => p.Id == inventoryId);

            return query;
        }

        public InventoryViewModel GetInventoryBy(long id)
        {
            var products = _shopContext.Products.Select(p => new { p.Id, p.Name });
            var query = _inventoryContext.Inventories.Select(p => new InventoryViewModel
            {
                Id = p.Id,
                ProductId = p.ProductId,

            }).FirstOrDefault(p => p.Id == id);

            query.Product = products.FirstOrDefault(p => p.Id == query.ProductId).Name;

            return query;


        }

        public List<ProductVarientViewModel> GetProductVarients(long inventoryId)
        {
            var inventory = _inventoryContext.Inventories.FirstOrDefault(p => p.Id == inventoryId);
            var colors = _inventoryContext.Colors.Select(p => new { p.Id, p.Name });
            var sizes = _inventoryContext.Sizes.Select(p => new { p.Id, p.Name });
            var query = inventory.productVariants.Select(p => new ProductVarientViewModel
            {
                Id = p.Id,
                InventoryId = p.InventoryId,
                ColorId = p.ColorId,
                SizeId = p.SizeId,
                Count = p.Count,
                UnitPrice = p.UnitPrice.ToString(),


            });




            var productsVarients = query.OrderByDescending(p => p.Id).ToList();
            foreach (var item in productsVarients)
            {
                item.Color = colors.FirstOrDefault(p => p.Id == item.ColorId).Name;
                item.Size = sizes.FirstOrDefault(p => p.Id == item.SizeId).Name;
            }

            return productsVarients;
        }

        public List<InventoryOperationsViewModel> InventoryOperations(long inventoryId)
        {
            var inventory = _inventoryContext.Inventories.FirstOrDefault(p => p.Id == inventoryId);

            var query = inventory.Operations.Select(p => new InventoryOperationsViewModel
            {
                Id = p.Id,
                Operation = p.Operation,
                Count = p.Count,
                OperatorId = p.OperatorId,
                Operator = "Admin",
                CreationDate = p.CreationDate.ToString("g"),
                CurrentCount = p.CurrentCount,
                Description = p.Describtion,
                OrderId = p.OrderId,
                InventoryId = p.InventoryId,
                ProductvarientId = p.ProductvarientId

            });

            return query.OrderByDescending(p => p.Id).ToList();
        }

        public List<InventoryOperationsViewModel> ProductVarientOperations(long inventoryId, long ProductVarientId)
        {
            var inventory = _inventoryContext.Inventories.FirstOrDefault(p => p.Id == inventoryId);

            var query = inventory.Operations.Where(p => p.ProductvarientId == ProductVarientId).Select(p => new InventoryOperationsViewModel
            {
                Id = p.Id,
                Operation = p.Operation,
                Count = p.Count,
                OperatorId = p.OperatorId,
                Operator = "Admin",
                CreationDate = p.CreationDate.ToString("g"),
                CurrentCount = p.CurrentCount,
                Description = p.Describtion,
                OrderId = p.OrderId,
                InventoryId = p.InventoryId,
                ProductvarientId = p.ProductvarientId

            });

            return query.OrderByDescending(p => p.Id).ToList();
        }
    }
}

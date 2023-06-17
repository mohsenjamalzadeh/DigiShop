using _01_framework.Domain;
using InventoryManagement.Application.Constract.Inventory;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepository : IRepository<long, Inventory>
    {
        List<InventoryViewModel> GetAll(InventorySearchModel searchModel);
        List<InventoryOperationsViewModel> InventoryOperations(long inventoryId);
        InventoryViewModel GetInventoryBy(long id);
        List<ProductVarientViewModel> GetProductVarients(long inventoryId);
        UpdateInventory GetDetails(long inventoryId);
        List<InventoryOperationsViewModel> ProductVarientOperations(long inventoryId,long ProductVarientId);


    }
}

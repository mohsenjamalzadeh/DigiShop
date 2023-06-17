using _01_framework.Application;

namespace InventoryManagement.Application.Constract.Inventory
{
    public interface IInventoryApplication
    {
        OperationResult Reduce(Reduce command);
        InventoryViewModel GetInventoryBy(long id);
        OperationResult Increase(Increase command);
        OperationResult Reduce(List<Reduce> command);
        UpdateInventory GetDetails(long inventoryId);
        OperationResult AddInventory(CreateInventory command);
        OperationResult EditInventory(UpdateInventory command);
        OperationResult AddProductVarient(AddProductVarient command);
        OperationResult ChangeProductVarientPrice(changePrice command);
        List<InventoryViewModel> GetAll(InventorySearchModel searchModel);
        List<ProductVarientViewModel> GetProductVarients(long inventoryId);
        List<InventoryOperationsViewModel> InventoryOperations(long inventoryId);
        List<InventoryOperationsViewModel> ProductVarientOperations(long inventoryId, long ProductVarientId);



    }



}

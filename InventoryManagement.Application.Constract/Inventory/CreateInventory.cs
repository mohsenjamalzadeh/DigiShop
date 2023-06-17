using ShopManagement.Application.Contracts.Product;

namespace InventoryManagement.Application.Constract.Inventory
{
    public class CreateInventory
    {
        public long ProductId { get; set; }
        public List<ProductViewModel> Products { set; get; }
    }



}

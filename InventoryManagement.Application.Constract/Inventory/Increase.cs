namespace InventoryManagement.Application.Constract.Inventory
{
    public class Increase
    {
        public long Count { get; set; }
        public string Description { get; set; }
        public long ProductVarientId { get; set; }
        public long InventoryId { get; set; }
    }



}

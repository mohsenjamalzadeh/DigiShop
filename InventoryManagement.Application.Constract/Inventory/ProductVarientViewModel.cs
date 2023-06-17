namespace InventoryManagement.Application.Constract.Inventory
{
    public class ProductVarientViewModel
    {
        public long Id { get; set; }
        public long InventoryId { get; set; }
        public int? ColorId { get; set; }
        public string Color { get; set; }
        public int? SizeId { get; set; }
        public string Size { get; set; }
        public long Count { get; set; }
        public string UnitPrice { get; set; }
    }



}

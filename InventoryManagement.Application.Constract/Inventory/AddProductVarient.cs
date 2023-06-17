using InventoryManagement.Application.Constract.Color;
using InventoryManagement.Application.Constract.Sizes;

namespace InventoryManagement.Application.Constract.Inventory
{
    public class AddProductVarient
    {

        public long InventoryId { get; set; }
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
        public long Count { get; set; }
        public double UnitPrice { get; set; }
        public string Description { get; set; }
        public List<ColorViewModel> Colors { get; set; }
        public List<SizeViewModel> Sizes { get; set; }
    }



}

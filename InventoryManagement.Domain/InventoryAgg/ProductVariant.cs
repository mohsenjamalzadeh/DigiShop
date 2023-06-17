using InventoryManagement.Domain.ColorAgg;
using InventoryManagement.Domain.SizeAgg;
using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class ProductVariant
    {
        
        public long Id { get;private  set; }
        public long InventoryId { get;private  set; }
        public int? ColorId { get;private  set; }
        public int? SizeId { get;private  set; }
        public double UnitPrice { get; private set; }
        public long Count { get; private set; }

        public Inventory Inventory { get;  set; }
    

        public ProductVariant(long inventoryId, int? colorId, int? sizeId, double unitPrice, long count)
        {
            InventoryId = inventoryId;
            ColorId = colorId;
            SizeId = sizeId;
            UnitPrice = unitPrice;
            Count = count;
        }

        public void Increase(long count) => Count +=count ;
        public void Decrease(long count) => Count -= count;
        public void ChangeUnitPrice(double unitPrice) => UnitPrice = unitPrice;
    }
}

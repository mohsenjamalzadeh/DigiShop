using _01_framework.Application;
using _01_framework.Domain;
using System.Drawing;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory : EntityBase
    {
        public long ProductId { get; private set; }
        public bool InStock { get; private set; }

        public List<ProductVariant> productVariants { get; private set; }
        public List<InventoryOperation> Operations { get; private set; }
        protected Inventory() { }


        public Inventory(long productId)
        {
            ProductId = productId;
            InStock = false;
        }

        public void Edit(long productId)
        {
            ProductId = productId;
        }


        public void AddProductVariant(long inventoryId, int? colorId, int? sizeId, double unitPrice, long count, string describtion, long operatorId)
        {
            var productvarient = new ProductVariant(inventoryId, colorId, sizeId, unitPrice, count);
            productVariants.Add(productvarient);
            InStock = productvarient.Count > 0;

        }

        public void AddOperationLog(bool operation, long count, long operatorId,
            long currentCount, string describtion, long orderId, long inventoryId, long productvarientId)
        {
            var operationLog=new InventoryOperation(operation,count,operatorId, currentCount,describtion,orderId,inventoryId,productvarientId);
            Operations.Add(operationLog);
           
        }

        public long CurrentCountInventory()
        {
            var plus = Operations.Where(p => p.Operation).Sum(p => p.Count);
            var minus = Operations.Where(p => p.Operation == false).Sum(p => p.Count);
            return plus - minus;
        }

        public long ProductVariantCurrent(long productVarient)
        {

            var plus = Operations.Where(p => p.ProductvarientId == productVarient).Where(p => p.Operation).Sum(p => p.Count);
            var minus = Operations.Where(p => p.ProductvarientId == productVarient).Where(p => p.Operation == false).Sum(p => p.Count);
            return plus - minus;
        }

        public void Increase(long count, long operatorId, string describtion, long ProductVariant)
        {
            var currentCount = ProductVariantCurrent(ProductVariant) + count;
            var productVarient = productVariants.FirstOrDefault(p => p.Id == ProductVariant);
            productVarient.Increase(count);
            AddOperationLog(true, count, operatorId, currentCount, describtion, 0, Id, ProductVariant);
            InStock = currentCount > 0;
        }

        public void Reduce(long count, long operatorId, string describtion, long orderid, long ProductVariant)
        {
            var currentCount = ProductVariantCurrent(ProductVariant) - count;
            var productVarient = productVariants.FirstOrDefault(p => p.Id == ProductVariant);
            productVarient.Decrease(count);
            AddOperationLog(false, count, operatorId, currentCount, describtion, orderid, Id, ProductVariant);
            InStock = currentCount > 0;

        }

        public void ChangePrice(long productVarientId, double unitprice)
        {
            var productVarient = productVariants.FirstOrDefault(p => p.Id == productVarientId);
            productVarient.ChangeUnitPrice(unitprice);
        }

    }
}

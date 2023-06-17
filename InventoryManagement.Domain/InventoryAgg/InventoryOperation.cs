namespace InventoryManagement.Domain.InventoryAgg
{
    public class InventoryOperation
    {
        public long Id { get;  set; }
        public bool Operation { get;private  set; }
        public long Count { get;private  set; }
        public long OperatorId { get;private  set; }
        public DateTime CreationDate { get;private  set; }
        public long CurrentCount { get;private  set; }
        public string Describtion { get;private  set; }
        public long OrderId { get;private  set; }
        public long InventoryId { get;private  set; }
        public long ProductvarientId { get;private  set; }

        public Inventory Inventory { get;private  set; }

        public InventoryOperation(bool operation, long count, long operatorId,
            long currentCount, string describtion, long orderId, long inventoryId, long productvarientId)
        {
            Operation = operation;
            Count = count;
            OperatorId = operatorId;
            CurrentCount = currentCount;
            Describtion = describtion;
            OrderId = orderId;
            InventoryId = inventoryId;
            ProductvarientId = productvarientId;
            CreationDate=DateTime.Now;
        }
    }
}

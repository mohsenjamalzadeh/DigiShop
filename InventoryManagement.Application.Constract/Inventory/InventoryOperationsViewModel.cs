namespace InventoryManagement.Application.Constract.Inventory
{
    public class InventoryOperationsViewModel
    {
        public long Id { get; set; }
        public bool Operation { get; set; }
        public long Count { get; set; }
        public long OperatorId { get; set; }
        public string Operator { get; set; }
        public string CreationDate { get; set; }
        public long CurrentCount { get; set; }
        public string Description { get; set; }
        public long OrderId { get; set; }
        public long InventoryId { get; set; }
        public long ProductvarientId { get; set; }

    }



}

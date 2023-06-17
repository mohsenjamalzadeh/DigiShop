using InventoryManagement.Domain.InventoryAgg;

namespace InventoryManagement.Domain.SizeAgg
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }

       

        public Size(string name)
        {
            Name = name;
        }


        public void Edit(string name)
        {
            Name = name;
        }
    }
}

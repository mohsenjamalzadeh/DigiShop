using InventoryManagement.Domain.InventoryAgg;

namespace InventoryManagement.Domain.ColorAgg
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HEX { get; set; }

     

        public Color(string name, string hEX)
        {

            Name = name;
            HEX = hEX;
        }

        public void Edit(string name, string hEX)
        {

            Name = name;
            HEX = hEX;
        }
    }
}

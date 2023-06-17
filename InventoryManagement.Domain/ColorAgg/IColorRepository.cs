using _01_framework.Domain;
using InventoryManagement.Application.Constract.Color;

namespace InventoryManagement.Domain.ColorAgg
{
    public interface IColorRepository:IRepository<int,Color>
    {
        EditColor GetDetails(int Id);
        List<ColorViewModel> GetAll();
    }
}

using _01_framework.Domain;
using InventoryManagement.Application.Constract.Sizes;

namespace InventoryManagement.Domain.SizeAgg
{
    public interface ISizeRepository : IRepository<int, Size>
    {
        EditSize GetDetails(int Id);
        List<SizeViewModel> GetAll();
    }

}

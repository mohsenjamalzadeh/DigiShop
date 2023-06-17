using _01_framework.Application;

namespace InventoryManagement.Application.Constract.Color
{
    public interface IColorApplication
    {
        OperationResult CreateColor(CreateColor command);
        OperationResult EditColor(EditColor command);
        EditColor GetDetails(int Id);
        List<ColorViewModel> GetAll();
    }



}

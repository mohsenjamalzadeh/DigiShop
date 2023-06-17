using _01_framework.Application;

namespace InventoryManagement.Application.Constract.Sizes;

    public interface ISizeApplication
    {
        OperationResult CreateSize(CreateSize command);
        OperationResult EditSize(EditSize command);
        EditSize GetDetails(int Id);
        List<SizeViewModel> GetAll();
    }





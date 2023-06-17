using _01_framework.Application;
using InventoryManagement.Application.Constract.Color;
using InventoryManagement.Domain.ColorAgg;

namespace InventoryManagement.Application
{
    public class ColorApplication : IColorApplication
    {
        private readonly IColorRepository _colorRepository;

        public ColorApplication(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }


        public OperationResult CreateColor(CreateColor command)
        {
            var operation = new OperationResult();

            if (_colorRepository.IsExist(p => p.Name == command.Name))
                return operation.Failed(ResultMessage.IsDoblicated);

            var color = new Color(command.Name, command.HEX);
            _colorRepository.Create(color);
            _colorRepository.SaveChanges();

            return operation.IsSucssed();

        }

        public OperationResult EditColor(EditColor command)
        {
            var operation = new OperationResult();

            var color = _colorRepository.GetBy(command.Id);
            if (color == null)
                return operation.Failed(ResultMessage.IsNotExistRecord);

            if (_colorRepository.IsExist(p => p.Name == command.Name && p.Id != command.Id))
                return operation.Failed(ResultMessage.IsDoblicated);

            color.Edit(command.Name, command.HEX);
            _colorRepository.SaveChanges();

            return operation.IsSucssed();

        }

        public List<ColorViewModel> GetAll()
        {
            return _colorRepository.GetAll();
        }

        public EditColor GetDetails(int Id)
        {
            return _colorRepository.GetDetails(Id);
        }
    }
}

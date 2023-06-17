using _01_framework.Application;
using InventoryManagement.Application.Constract.Sizes;
using InventoryManagement.Domain.SizeAgg;
using System.Drawing;
using Size = InventoryManagement.Domain.SizeAgg.Size;

namespace InventoryManagement.Application
{
    public class SizeApplication : ISizeApplication
    {
        private readonly ISizeRepository _sizeRepository;

        public SizeApplication(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public OperationResult CreateSize(CreateSize command)
        {
            var operation = new OperationResult();

            if (_sizeRepository.IsExist(p => p.Name == command.Name))
                return operation.Failed(ResultMessage.IsDoblicated);

            var size = new Size(command.Name);
            _sizeRepository.Create(size);
            _sizeRepository.SaveChanges();

            return operation.IsSucssed();
        }

        public OperationResult EditSize(EditSize command)
        {
            var operation = new OperationResult();

            var size = _sizeRepository.GetBy(command.Id);
            if (size == null)
                return operation.Failed(ResultMessage.IsNotExistRecord);

            if (_sizeRepository.IsExist(p => p.Name == command.Name && p.Id != command.Id))
                return operation.Failed(ResultMessage.IsDoblicated);

            size.Edit(command.Name);
            _sizeRepository.SaveChanges();

            return operation.IsSucssed();

        }

        public List<SizeViewModel> GetAll()
        {
           return _sizeRepository.GetAll();
        }

        public EditSize GetDetails(int Id)
        {
            return _sizeRepository.GetDetails(Id);
        }
    }
}

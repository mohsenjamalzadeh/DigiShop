using _01_framework.Application;
using InventoryManagement.Application.Constract.Inventory;
using InventoryManagement.Domain.InventoryAgg;

namespace InventoryManagement.Application
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository _invantoryRepository;

        public InventoryApplication(IInventoryRepository invantoryRepository)
        {
            _invantoryRepository = invantoryRepository;
        }

        public OperationResult AddInventory(CreateInventory command)
        {
            var operation = new OperationResult();
            if (_invantoryRepository.IsExist(p => p.ProductId == command.ProductId))
                return operation.Failed(ResultMessage.IsDoblicated);

            var inventory = new Inventory(command.ProductId);
            _invantoryRepository.Create(inventory);
            _invantoryRepository.SaveChanges();

            return operation.IsSucssed();

        }

        public OperationResult AddProductVarient(AddProductVarient command)
        {
            var operation = new OperationResult();

            var Inventory = _invantoryRepository.GetBy(command.InventoryId);
            if (Inventory is null)
                return operation.Failed(ResultMessage.IsNotExistRecord);
            if (_invantoryRepository.IsExist(p => (p.productVariants.Any(p => p.ColorId == command.ColorId && p.SizeId == command.SizeId && p.InventoryId == command.InventoryId))))
                return operation.Failed(ResultMessage.IsDoblicated);

            Inventory.AddProductVariant(command.InventoryId, command.ColorId, command.SizeId, command.UnitPrice, command.Count, command.Description, 0);
            _invantoryRepository.SaveChanges();

            var productVarientId = Inventory.productVariants.Last().Id;
            Inventory.AddOperationLog(true, command.Count, 0, Inventory.CurrentCountInventory(), command.Description, 0, command.InventoryId, productVarientId);
            _invantoryRepository.SaveChanges();

            return operation.IsSucssed();

        }

        public OperationResult ChangeProductVarientPrice(changePrice command)
        {
            var operation = new OperationResult();

            var inventory = _invantoryRepository.GetBy(command.InventoryId);
            if (inventory is null)
                return operation.Failed(ResultMessage.IsNotExistRecord);

            inventory.ChangePrice(command.ProductVarientId, command.UnitPrice);
            _invantoryRepository.SaveChanges();

            return operation.IsSucssed();

        }

        public OperationResult EditInventory(UpdateInventory command)
        {
            var operation = new OperationResult();
            var inventory = _invantoryRepository.GetBy(command.Id);
            if (inventory is null)
                return operation.Failed(ResultMessage.IsNotExistRecord);

            if (_invantoryRepository.IsExist(p => p.ProductId == command.Id && p.Id != command.Id))
                return operation.Failed(ResultMessage.IsDoblicated);

            inventory.Edit(command.ProductId);
            _invantoryRepository.SaveChanges();

            return operation.IsSucssed();
        }

        public List<InventoryViewModel> GetAll(InventorySearchModel searchModel)
        {
            return _invantoryRepository.GetAll(searchModel);
        }

        public UpdateInventory GetDetails(long inventoryId)
        {
            return _invantoryRepository.GetDetails(inventoryId);
        }

        public InventoryViewModel GetInventoryBy(long id)
        {
            return _invantoryRepository.GetInventoryBy(id);
        }

        public List<ProductVarientViewModel> GetProductVarients(long inventoryId)
        {
            return _invantoryRepository.GetProductVarients(inventoryId);
        }

        public OperationResult Increase(Increase command)
        {
            var operation = new OperationResult();
            var inventory = _invantoryRepository.GetBy(command.InventoryId);
            if (inventory is null)
                return operation.Failed(ResultMessage.IsNotExistRecord);

            inventory.Increase(command.Count, 0, command.Description, command.ProductVarientId);
            _invantoryRepository.SaveChanges();

            return operation.IsSucssed();
        }

        public List<InventoryOperationsViewModel> InventoryOperations(long inventoryId)
        {
            return _invantoryRepository.InventoryOperations(inventoryId);
        }

        public List<InventoryOperationsViewModel> ProductVarientOperations(long inventoryId,long ProductVarientId)
        {
            return _invantoryRepository.ProductVarientOperations(inventoryId,ProductVarientId);
        }

        public OperationResult Reduce(Reduce command)
        {
            var operation = new OperationResult();
            var inventory = _invantoryRepository.GetBy(command.InventoryId);

            if (inventory is null)
                return operation.Failed(ResultMessage.IsNotExistRecord);

            inventory.Reduce(command.Count, 0, command.Description, command.OrderId, command.ProductVariant);
            _invantoryRepository.SaveChanges();
            return operation.IsSucssed();
        }

        public OperationResult Reduce(List<Reduce> command)
        {
            var operation = new OperationResult();

            foreach (var item in command)
            {
                var invertory = _invantoryRepository.GetBy(item.InventoryId);
                if (invertory is null)
                    break;

                invertory.Reduce(item.Count, 0, item.Description, item.OrderId, item.ProductVariant);

            }
            _invantoryRepository.SaveChanges();

            return operation.IsSucssed();

        }
    }
}
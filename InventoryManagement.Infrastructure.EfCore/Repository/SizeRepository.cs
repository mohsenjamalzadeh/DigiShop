using _01_framework.Infrastructure;
using InventoryManagement.Application.Constract.Sizes;
using InventoryManagement.Domain.SizeAgg;

namespace InventoryManagement.Infrastructure.EfCore.Repository
{
    public class SizeRepository : RepositoryBase<int, Size>, ISizeRepository
    {
        private readonly InventoryContext _inventoryContext;

        public SizeRepository(InventoryContext inventoryContext) : base(inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }

        public EditSize GetDetails(int Id)
        {
            var query = _inventoryContext.Sizes.Select(p => new EditSize
            {
                Id = p.Id,
                Name = p.Name,

            }).FirstOrDefault(p => p.Id == Id);

            return query;
        }

        List<SizeViewModel> ISizeRepository.GetAll()
        {
            var query = _inventoryContext.Sizes.Select(p => new SizeViewModel
            {
                Id = p.Id,
                Name = p.Name,

            });

            return query.OrderByDescending(p => p.Id).ToList();
        }
    }
}

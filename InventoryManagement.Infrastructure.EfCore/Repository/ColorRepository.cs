using _01_framework.Infrastructure;
using InventoryManagement.Application.Constract.Color;
using InventoryManagement.Domain.ColorAgg;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.EfCore.Repository
{
    public class ColorRepository : RepositoryBase<int, Color>, IColorRepository
    {
        private readonly InventoryContext _inventoryContext;

        public ColorRepository(InventoryContext inventoryContext) : base(inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }

        public EditColor GetDetails(int Id)
        {
            var query = _inventoryContext.Colors.Select(p => new EditColor
            {
                Id = p.Id,
                Name = p.Name,
                HEX = p.HEX
            }).FirstOrDefault(p => p.Id == Id);

            return query;
        }

        List<ColorViewModel> IColorRepository.GetAll()
        {
            var query = _inventoryContext.Colors.Select(p => new ColorViewModel
            {
                Id = p.Id,
                Name = p.Name,
                HEX = p.HEX
            });

            return query.OrderByDescending(p => p.Id).ToList();
        }
    }
}

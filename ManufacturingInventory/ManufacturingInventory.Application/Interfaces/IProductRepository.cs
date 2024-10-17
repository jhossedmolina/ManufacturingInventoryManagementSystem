using ManufacturingInventory.Domain.Entities;

namespace ManufacturingInventory.Application.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        List<Product> GetProductsByStatus(string status);

        Task<bool> MarkProductAsDefective(int id);
    }
}

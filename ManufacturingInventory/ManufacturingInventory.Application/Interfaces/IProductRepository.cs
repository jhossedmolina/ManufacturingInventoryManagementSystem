using ManufacturingInventory.Domain.Entities;

namespace ManufacturingInventory.Application.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        List<Product> GetProductsByStatus(string status);

        Task<Product> GetProductById(int id);

        Task AddProducts(Product product);

        Task<bool> MarkProductAsDefective(int id);

        Task<bool> UpdateProduct(Product product);

        Task<bool> DeleteProduct(int id);
    }
}

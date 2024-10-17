using ManufacturingInventory.Domain.Entities;

namespace ManufacturingInventory.Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();

        List<Product> GetProductsByStatus(string status);

        Task AddProducts(Product product);

        Task<bool> UpdateProductStatus(Product product);

        Task<bool> DeleteProduct(int id);
    }
}

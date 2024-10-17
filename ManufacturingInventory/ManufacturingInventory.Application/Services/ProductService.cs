using ManufacturingInventory.Application.Interfaces;
using ManufacturingInventory.Domain.Entities;

namespace ManufacturingInventory.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public List<Product> GetProductsByStatus(string status)
        {
            return _productRepository.GetProductsByStatus(status);
        }

        public async Task AddProducts(Product product)
        {
            await _productRepository.AddProducts(product);
        }

        public Task<bool> UpdateProductStatus(Product product)
        {
            return _productRepository.UpdateProductStatus(product);
        }

        public Task<bool> DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }
    }
}

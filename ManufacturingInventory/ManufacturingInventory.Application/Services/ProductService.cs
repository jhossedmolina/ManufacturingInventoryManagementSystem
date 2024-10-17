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

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task AddProducts(Product product)
        {
            product.ProductionType = product.ProductionType.Replace('_', ' ');
            product.Status = product.Status!.Replace('_', ' ');
            await _productRepository.AddProducts(product);
        }

        public async Task<bool> MarkProductAsDefective(int id)
        {
            return await _productRepository.MarkProductAsDefective(id);
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            product.ProductionType = product.ProductionType.Replace('_', ' ');
            product.Status = product.Status!.Replace('_', ' ');
            return await _productRepository.UpdateProduct(product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _productRepository.DeleteProduct(id);
        }
    }
}

using ManufacturingInventory.Application.Exceptions;
using ManufacturingInventory.Application.Interfaces;
using ManufacturingInventory.Domain.Entities;

namespace ManufacturingInventory.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _unitOfWork.ProductRepository.GetAll().OrderBy(x => x.Status);
        }

        public List<Product> GetProductsByStatus(string status)
        {
            return _productRepository.GetProductsByStatus(status);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _unitOfWork.ProductRepository.GetById(id);
        }

        public async Task AddProducts(Product product)
        {
            var products = GetAllProducts().Where(x => x.Name == product.Name).ToList();
            if (products.Count > 0)
                throw new GlobalException($"Ya existe un producto con el nombre {product.Name}");

            product.ProductionType = product.ProductionType.Replace('_', ' ');
            product.Status = product.Status!.Replace('_', ' ');
            await _unitOfWork.ProductRepository.Add(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> MarkProductAsDefective(int id)
        {
            var currentProduct = await GetProductById(id);
            if (currentProduct is null)
                throw new GlobalException($"No existe un producto con el Id {id}.");

            return await _productRepository.MarkProductAsDefective(id);
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var products = GetAllProducts().Where(x => x.Name == product.Name).ToList();
            if (products.Count > 0)
                throw new GlobalException($"Ya existe un producto con el nombre {product.Name}");

            product.ProductionType = product.ProductionType.Replace('_', ' ');
            product.Status = product.Status!.Replace('_', ' ');
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var currentProduct = await GetProductById(id);
            if (currentProduct is null)
                throw new GlobalException($"No existe un producto con el Id {id}.");

            await _unitOfWork.ProductRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}

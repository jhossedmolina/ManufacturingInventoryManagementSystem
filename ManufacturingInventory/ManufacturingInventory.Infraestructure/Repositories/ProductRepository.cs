using ManufacturingInventory.Application.Interfaces;
using ManufacturingInventory.Domain.Entities;
using ManufacturingInventory.Infraestructure.DataAccess;

namespace ManufacturingInventory.Infraestructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ManufacturingInventoryDbContext _context;

        public ProductRepository(ManufacturingInventoryDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList().OrderBy(p => p.Status);
        }

        public List<Product> GetProductsByStatus(string status)
        {
            return _context.Products.Where(p => p.Status == status).ToList();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddProducts(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> MarkProductAsDefective(int id)
        {
            var currentProduct = await GetProductById(id);
            currentProduct.Status = "Defectuoso";
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var currentProduct = await GetProductById(product.Id);
            currentProduct.Name = product.Name;
            currentProduct.ProductionType = product.ProductionType;
            currentProduct.Status = product.Status;
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var currentProduct = await GetProductById(id);
            _context.Products.Remove(currentProduct);
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}

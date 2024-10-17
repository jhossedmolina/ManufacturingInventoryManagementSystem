using ManufacturingInventory.Application.Interfaces;
using ManufacturingInventory.Domain.Entities;
using ManufacturingInventory.Infraestructure.DataAccess;

namespace ManufacturingInventory.Infraestructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {        
        public ProductRepository(ManufacturingInventoryDbContext context) : base(context)
        {
        }

        public List<Product> GetProductsByStatus(string status)
        {
            return _context.Products.Where(p => p.Status == status).ToList();
        }

        private async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<bool> MarkProductAsDefective(int id)
        {
            var currentProduct = await GetProductById(id);
            currentProduct.Status = "Defectuoso";
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}

using ManufacturingInventory.Application.Interfaces;
using ManufacturingInventory.Infraestructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ManufacturingInventory.Infraestructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ManufacturingInventoryDbContext _context;
        private readonly DbSet<T> _entities;

        public GenericRepository(ManufacturingInventoryDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }
    }
}

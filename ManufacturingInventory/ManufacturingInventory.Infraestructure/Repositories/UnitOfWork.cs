using ManufacturingInventory.Application.Interfaces;
using ManufacturingInventory.Domain.Entities;
using ManufacturingInventory.Infraestructure.DataAccess;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingInventory.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ManufacturingInventoryDbContext _context;
        private readonly IGenericRepository<Product> _productRepository;

        public UnitOfWork(ManufacturingInventoryDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Product> ProductRepository => _productRepository ?? new GenericRepository<Product>(_context);

        public void Dispose() 
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

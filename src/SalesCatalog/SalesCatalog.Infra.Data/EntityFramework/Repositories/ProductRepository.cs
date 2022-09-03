using Microsoft.EntityFrameworkCore;
using SalesCatalog.Domain.Entities;
using SalesCatalog.Domain.Interfaces;
using SalesCatalog.Infra.Data.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesCatalog.Infra.Data.EntityFramework.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);

            return product;
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> GetProductCategoryAsync(Guid guid)
        {
            return await _context.Products.Include(c => c.Category)
                .SingleOrDefaultAsync(p => p.Id == guid);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }

        public Product Update(Product product)
        {
            _context.Products.Update(product);

            return product;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}

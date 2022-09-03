﻿using Microsoft.EntityFrameworkCore;
using SalesCatalog.Domain.Entities;
using SalesCatalog.Domain.Interfaces;
using SalesCatalog.Infra.Data.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesCatalog.Infra.DataEntityFramework.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);

            return category;
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        public void Remove(Category category)
        {
            _context.Categories.Remove(category);
        }

        public Category Update(Category category)
        {
            _context.Categories.Update(category);

            return category;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}

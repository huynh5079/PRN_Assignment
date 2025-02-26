using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _context;

        public CategoryRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "DatabaseContext cannot be null");
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> CreateAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Category> UpdateAsync(Category entity)
        {
            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Category> DeleteAsync(Category entity)
        {
            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

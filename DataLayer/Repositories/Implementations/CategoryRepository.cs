using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;

namespace DataLayer.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Category> _dbSet;

        public CategoryRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<Category>();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(Category category)
        {
            await _dbSet.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _dbSet.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _dbSet.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsCategoryUsedAsync(int categoryId)
        {
            return await _context.NewsArticles.AnyAsync(n => n.CategoryId == categoryId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

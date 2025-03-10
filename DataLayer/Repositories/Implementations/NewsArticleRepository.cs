using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;

namespace DataLayer.Repositories.Implementations
{
    public class NewsArticleRepository : INewsArticleRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<NewsArticle> _dbSet;

        public NewsArticleRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<NewsArticle>();
        }

        public async Task<IEnumerable<NewsArticle>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<NewsArticle?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(NewsArticle newsArticle)
        {
            await _dbSet.AddAsync(newsArticle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(NewsArticle newsArticle)
        {
            _dbSet.Update(newsArticle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(NewsArticle newsArticle)
        {
            _dbSet.Remove(newsArticle);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<NewsArticle>> GetNewsByCategoryAsync(int categoryId)
        {
            return await _dbSet.Where(n => n.CategoryId == categoryId).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

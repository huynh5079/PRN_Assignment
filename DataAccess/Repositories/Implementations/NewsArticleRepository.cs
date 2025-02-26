using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Implementations
{
    public class NewsArticleRepository : INewsArticleIRepository
    {
        private readonly DatabaseContext _context;

        public NewsArticleRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "DatabaseContext cannot be null");
        }

        public async Task<IEnumerable<NewsArticle>> GetAllAsync()
        {
            return await _context.NewsArticles.ToListAsync();
        }

        public async Task<NewsArticle?> GetByIdAsync(int id)
        {
            return await _context.NewsArticles.FindAsync(id);
        }

        public async Task<NewsArticle> CreateAsync(NewsArticle entity)
        {
            await _context.NewsArticles.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<NewsArticle> UpdateAsync(NewsArticle entity)
        {
            _context.NewsArticles.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<NewsArticle> DeleteAsync(NewsArticle entity)
        {
            _context.NewsArticles.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

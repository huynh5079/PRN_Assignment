using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;

namespace DataLayer.Repositories.Implementations
{
    public class TagRepository : ITagRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Tag> _dbSet;

        public TagRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<Tag>();
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Tag?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(Tag tag)
        {
            await _dbSet.AddAsync(tag);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tag tag)
        {
            _dbSet.Update(tag);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Tag tag)
        {
            _dbSet.Remove(tag);
            await _context.SaveChangesAsync();
        }

        public async Task<Tag?> GetTagByNameAsync(string tagName)
        {
            return await _dbSet.FirstOrDefaultAsync(t => t.TagName == tagName);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

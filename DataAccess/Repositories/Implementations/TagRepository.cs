using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Implementations
{
    public class TagRepository : ITagRepository
    {
        private readonly DatabaseContext _context;

        public TagRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "DatabaseContext cannot be null");
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag?> GetByIdAsync(int id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public async Task<Tag> CreateAsync(Tag entity)
        {
            await _context.Tags.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Tag> UpdateAsync(Tag entity)
        {
            _context.Tags.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Tag> DeleteAsync(Tag entity)
        {
            _context.Tags.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DatabaseContext _context;

        public AccountRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "DatabaseContext cannot be null");
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<Account> CreateAsync(Account entity)
        {
            await _context.Accounts.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Account> UpdateAsync(Account entity)
        {
            _context.Accounts.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Account> DeleteAsync(Account entity)
        {
            _context.Accounts.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

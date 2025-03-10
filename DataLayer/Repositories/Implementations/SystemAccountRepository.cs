using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;

namespace DataLayer.Repositories.Implementations
{
    public class SystemAccountRepository : ISystemAccountRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<SystemAccount> _dbSet;

        public SystemAccountRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<SystemAccount>();
        }

        public async Task<IEnumerable<SystemAccount>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<SystemAccount?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(SystemAccount account)
        {
            await _dbSet.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SystemAccount account)
        {
            _dbSet.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(SystemAccount account)
        {
            _dbSet.Remove(account);
            await _context.SaveChangesAsync();
        }

        public async Task<SystemAccount?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.AccountEmail == email);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

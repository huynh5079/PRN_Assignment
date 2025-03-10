using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using BusinessLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class SystemAccountService : ISystemAccountService
    {
        private readonly ISystemAccountRepository _systemAccountRepository;

        public SystemAccountService(ISystemAccountRepository systemAccountRepository)
        {
            _systemAccountRepository = systemAccountRepository;
        }

        public async Task<IEnumerable<SystemAccount>> GetAllAccountsAsync()
        {
            return await _systemAccountRepository.GetAllAsync();
        }

        public async Task<SystemAccount?> GetAccountByIdAsync(int id)
        {
            return await _systemAccountRepository.GetByIdAsync(id);
        }

        public async Task<SystemAccount?> GetAccountByEmailAsync(string email)
        {
            return await _systemAccountRepository.GetByEmailAsync(email);
        }

        public async Task AddAccountAsync(SystemAccount account)
        {
            await _systemAccountRepository.AddAsync(account);
        }

        public async Task UpdateAccountAsync(SystemAccount account)
        {
            await _systemAccountRepository.UpdateAsync(account);
        }

        public async Task DeleteAccountAsync(SystemAccount account)
        {
            await _systemAccountRepository.DeleteAsync(account);
        }
    }
}

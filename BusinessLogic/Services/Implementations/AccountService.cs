using BusinessLayer.Services.Interfaces;
using DataLayer.Entities;
using DataLayer.Repositories.Implementations;
using DataLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _accountRepository.GetAllAsync();
        }

        public async Task<Account?> GetAccountByIdAsync(int id)
        {
            return await _accountRepository.GetByIdAsync(id);
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
            return await _accountRepository.CreateAsync(account);
        }

        public async Task<Account> UpdateAccountAsync(Account account)
        {
            return await _accountRepository.UpdateAsync(account);
        }

        public async Task<bool> DeleteAccountAsync(int id)
        {
            var account = await _accountRepository.GetByIdAsync(id);
            if (account == null)
            {
                return false;
            }

            await _accountRepository.DeleteAsync(account);
            return true;
        }
    }
}

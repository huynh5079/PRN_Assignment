using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using BusinessLayer.Services.Interfaces;
using BusinessLayer.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using DataLayer.Repositories.Implementations;

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


        public async Task<bool> RegisterAsync(string name, string email, string password, int role)
        {
            var hashedPassword = PasswordHasher.HashPassword(password); 

            var account = new SystemAccount
            {
                AccountName = name,
                AccountEmail = email,
                AccountPassword = hashedPassword,
                AccountRole = role
            };

            await _systemAccountRepository.AddAsync(account);
            return true;
        }

        public async Task<SystemAccount?> AuthenticateAsync(string identifier, string password)
        {
            SystemAccount? user = await _systemAccountRepository.GetByAccountNameAsync(identifier)
                                  ?? await _systemAccountRepository.GetByEmailAsync(identifier);

            if (user == null)
            {
                Console.WriteLine("User not found: " + identifier);
                return null;
            }

            Console.WriteLine($"User found: {user.AccountName}, Hashed Password: {user.AccountPassword}");

            if (!VerifyPassword(password, user.AccountPassword))
            {
                Console.WriteLine($"Password mismatch: Entered {password} | Stored {user.AccountPassword}");
                return null;
            }

            return user;
        }

        private bool VerifyPassword(string inputPassword, string storedPassword)
        {
            string hashedInput = PasswordHasher.HashPassword(inputPassword);
            Console.WriteLine($"Comparing: {hashedInput} == {storedPassword}");
            return hashedInput == storedPassword;
        }
    }
}

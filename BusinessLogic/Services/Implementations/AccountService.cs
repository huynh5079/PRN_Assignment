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
        private readonly INewsArticleIRepository _newsArticleIRepository;
        private readonly ITagRepository _tagRepository;


        public AccountService(IAccountRepository accountRepository, INewsArticleIRepository newsArticleIRepository, ITagRepository tagRepository)
        {
            _accountRepository = accountRepository;
            _newsArticleIRepository = newsArticleIRepository;
            _tagRepository = tagRepository;
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
            if (account == null) return false;

            var articles = await _newsArticleIRepository.GetAllAsync();
            var articlesToDelete = articles.Where(n => n.AuthorId == id).ToList();

            foreach (var article in articlesToDelete)
            {
                var tags = await _tagRepository.GetAllAsync();
                var tagsToDelete = tags.Where(t => t.NewsArticleId == article.Id).ToList();

                foreach (var tag in tagsToDelete)
                {
                    await _tagRepository.DeleteAsync(tag);
                }

                await _newsArticleIRepository.DeleteAsync(article);
            }

            await _accountRepository.DeleteAsync(account);

            return true;
        }


    }
}

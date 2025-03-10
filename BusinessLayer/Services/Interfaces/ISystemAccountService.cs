using DataLayer.Entities;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface ISystemAccountService
    {
        Task<IEnumerable<SystemAccount>> GetAllAccountsAsync();
        Task<SystemAccount?> GetAccountByIdAsync(int id);
        Task<SystemAccount?> GetAccountByEmailAsync(string email);
        Task AddAccountAsync(SystemAccount account);
        Task UpdateAccountAsync(SystemAccount account);
        Task DeleteAccountAsync(SystemAccount account);
    }
}

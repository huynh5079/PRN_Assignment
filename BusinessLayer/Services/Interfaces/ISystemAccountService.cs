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

        //login
        Task<SystemAccount?> AuthenticateAsync(string identifier, string password);
        Task<bool> RegisterAsync(string name, string email, string password, int role);

    }
}

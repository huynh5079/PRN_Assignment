using DataLayer.Entities;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Interfaces
{
    public interface ISystemAccountRepository : IRepository<SystemAccount>
    {
        Task<SystemAccount?> GetByEmailAsync(string email);
        Task<SystemAccount?> GetByAccountNameAsync(string name);
    }
}

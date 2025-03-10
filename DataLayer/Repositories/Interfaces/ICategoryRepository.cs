using DataLayer.Entities;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<bool> IsCategoryUsedAsync(int categoryId);
    }
}

using DataLayer.Entities;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Interfaces
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<Tag?> GetTagByNameAsync(string tagName);
    }
}

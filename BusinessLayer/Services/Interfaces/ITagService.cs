using DataLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAllTagsAsync();
        Task<Tag?> GetTagByIdAsync(int id);
        Task<Tag?> GetTagByNameAsync(string tagName);
        Task AddTagAsync(Tag tag);
        Task UpdateTagAsync(Tag tag);
        Task DeleteTagAsync(Tag tag);
    }
}

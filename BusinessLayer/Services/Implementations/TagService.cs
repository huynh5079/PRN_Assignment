using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using BusinessLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            return await _tagRepository.GetAllAsync();
        }

        public async Task<Tag?> GetTagByIdAsync(int id)
        {
            return await _tagRepository.GetByIdAsync(id);
        }

        public async Task<Tag?> GetTagByNameAsync(string tagName)
        {
            return await _tagRepository.GetTagByNameAsync(tagName);
        }

        public async Task AddTagAsync(Tag tag)
        {
            await _tagRepository.AddAsync(tag);
        }

        public async Task UpdateTagAsync(Tag tag)
        {
            await _tagRepository.UpdateAsync(tag);
        }

        public async Task DeleteTagAsync(Tag tag)
        {
            await _tagRepository.DeleteAsync(tag);
        }
    }
}

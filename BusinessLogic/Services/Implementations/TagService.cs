using BusinessLayer.Services.Interfaces;
using BusinessLayer.Services.Interfaces;
using DataLayer.Entities;
using DataLayer.Repositories.Implementations;
using DataLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Implementations
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

        public async Task<Tag> CreateTagAsync(Tag tag)
        {
            return await _tagRepository.CreateAsync(tag);
        }

        public async Task<Tag> UpdateTagAsync(Tag tag)
        {
            return await _tagRepository.UpdateAsync(tag);
        }

        public async Task<bool> DeleteTagAsync(int id)
        {
            var tag = await _tagRepository.GetByIdAsync(id);
            if (tag == null)
            {
                return false;
            }

            await _tagRepository.DeleteAsync(tag);
            return true;
        }
    }
}

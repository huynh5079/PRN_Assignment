using BusinessLayer.Services.Interfaces;
using DataLayer.Entities;
using DataLayer.Repositories.Implementations;
using DataLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            return await _categoryRepository.CreateAsync(category);
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            return await _categoryRepository.UpdateAsync(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return false;
            }

            await _categoryRepository.DeleteAsync(category);
            return true;
        }
    }
}

using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using BusinessLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
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

        public async Task<bool> IsCategoryUsedAsync(int categoryId)
        {
            return await _categoryRepository.IsCategoryUsedAsync(categoryId);
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            await _categoryRepository.DeleteAsync(category);
        }
    }
}

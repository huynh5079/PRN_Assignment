using DataLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<bool> IsCategoryUsedAsync(int categoryId);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Category category);
    }
}

using BusinessLayer.Services.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Huynhnmt_SE17C04_A02.Pages.Categories
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public IndexModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task OnGetAsync()
        {
            Categories = (List<Category>)await _categoryService.GetAllCategoriesAsync();
        }
    }
}

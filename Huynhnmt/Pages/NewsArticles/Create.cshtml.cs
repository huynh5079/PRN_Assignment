using BusinessLayer.Services.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Huynhnmt_SE17C04_A02.Pages.NewsArticles
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly INewsArticleService _newsArticleService;
        private readonly ICategoryService _categoryService;

        public CreateModel(INewsArticleService newsArticleService, ICategoryService categoryService)
        {
            _newsArticleService = newsArticleService;
            _categoryService = categoryService;
        }

        [BindProperty]
        public NewsArticle NewsArticle { get; set; } = new NewsArticle();

        public List<SelectListItem> CategoryList { get; set; } = new List<SelectListItem>();

        public async Task OnGetAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            CategoryList = categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync(); // Reload the category list if validation fails
                return Page();
            }

            NewsArticle.CreatedDate = DateTime.Now;
            await _newsArticleService.AddNewsAsync(NewsArticle);
            return RedirectToPage("./Index");
        }
    }
}

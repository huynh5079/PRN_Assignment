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
    public class EditModel : PageModel
    {
        private readonly INewsArticleService _newsArticleService;
        private readonly ICategoryService _categoryService;

        public EditModel(INewsArticleService newsArticleService, ICategoryService categoryService)
        {
            _newsArticleService = newsArticleService;
            _categoryService = categoryService;
        }

        [BindProperty]
        public NewsArticle NewsArticle { get; set; } = new NewsArticle();

        public List<SelectListItem> CategoryList { get; set; } = new List<SelectListItem>();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var news = await _newsArticleService.GetNewsByIdAsync(id);
            if (news == null)
                return NotFound();

            NewsArticle = news;

            var categories = await _categoryService.GetAllCategoriesAsync();
            CategoryList = categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync(NewsArticle.NewsArticleId); // Reload categories if validation fails
                return Page();
            }

            await _newsArticleService.UpdateNewsAsync(NewsArticle);
            return RedirectToPage("./Index");
        }
    }
}

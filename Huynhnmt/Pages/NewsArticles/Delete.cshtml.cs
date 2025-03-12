using BusinessLayer.Services.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Huynhnmt_SE17C04_A02.Pages.NewsArticles
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly INewsArticleService _newsArticleService;

        public DeleteModel(INewsArticleService newsArticleService)
        {
            _newsArticleService = newsArticleService;
        }

        [BindProperty]
        public NewsArticle NewsArticle { get; set; } = new NewsArticle();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            NewsArticle = await _newsArticleService.GetNewsByIdAsync(id);
            if (NewsArticle == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (NewsArticle == null)
                return NotFound();

            await _newsArticleService.DeleteNewsAsync(NewsArticle);
            return RedirectToPage("./Index");
        }
    }
}

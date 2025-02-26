using BusinessLayer.Services.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HuynhnmtMVC.Controllers
{
    public class NewsArticleController : Controller
    {
        private readonly INewsArticleService _newsService;

        public NewsArticleController(INewsArticleService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IActionResult> Index(string search)
        {
            var newsArticles = await _newsService.GetAllNewsArticlesAsync();
            if (!string.IsNullOrEmpty(search))
            {
                newsArticles = newsArticles.Where(n => n.Title.Contains(search));
            }
            return View(newsArticles);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(NewsArticle newsArticle)
        {
            if (!ModelState.IsValid) return View(newsArticle);
            await _newsService.CreateNewsArticleAsync(newsArticle);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var newsArticle = await _newsService.GetNewsArticleByIdAsync(id);
            if (newsArticle == null) return NotFound();
            return View(newsArticle);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NewsArticle newsArticle)
        {
            if (!ModelState.IsValid) return View(newsArticle);
            await _newsService.UpdateNewsArticleAsync(newsArticle);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var newsArticle = await _newsService.GetNewsArticleByIdAsync(id);
            if (newsArticle == null) return NotFound();
            return View(newsArticle);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsArticle = await _newsService.GetNewsArticleByIdAsync(id);
            if (newsArticle != null) await _newsService.DeleteNewsArticleAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

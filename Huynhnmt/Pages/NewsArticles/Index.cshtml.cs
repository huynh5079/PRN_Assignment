using BusinessLayer.Services.Interfaces;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Huynhnmt_SE17C04_A02.Pages.NewsArticles
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        private readonly INewsArticleService _newsArticleService;

        public IndexModel(INewsArticleService newsArticleService)
        {
            _newsArticleService = newsArticleService;
        }

        public List<NewsArticle> NewsArticles { get; set; } = new List<NewsArticle>();

        public async Task OnGetAsync()
        {
            NewsArticles = (List<NewsArticle>)await _newsArticleService.GetAllNewsAsync();
        }
    }
}

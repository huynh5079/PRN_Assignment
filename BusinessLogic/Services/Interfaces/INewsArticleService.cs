using DataLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface INewsArticleService
    {
        Task<IEnumerable<NewsArticle>> GetAllNewsArticlesAsync();
        Task<NewsArticle?> GetNewsArticleByIdAsync(int id);
        Task<NewsArticle> CreateNewsArticleAsync(NewsArticle newsArticle);
        Task<NewsArticle> UpdateNewsArticleAsync(NewsArticle newsArticle);
        Task<bool> DeleteNewsArticleAsync(int id);
    }
}

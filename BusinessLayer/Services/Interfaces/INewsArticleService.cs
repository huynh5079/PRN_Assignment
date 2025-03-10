using DataLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface INewsArticleService
    {
        Task<IEnumerable<NewsArticle>> GetAllNewsAsync();
        Task<NewsArticle?> GetNewsByIdAsync(int id);
        Task<IEnumerable<NewsArticle>> GetNewsByCategoryAsync(int categoryId);
        Task AddNewsAsync(NewsArticle newsArticle);
        Task UpdateNewsAsync(NewsArticle newsArticle);
        Task DeleteNewsAsync(NewsArticle newsArticle);
    }
}

using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using BusinessLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class NewsArticleService : INewsArticleService
    {
        private readonly INewsArticleRepository _newsArticleRepository;

        public NewsArticleService(INewsArticleRepository newsArticleRepository)
        {
            _newsArticleRepository = newsArticleRepository;
        }

        public async Task<IEnumerable<NewsArticle>> GetAllNewsAsync()
        {
            return await _newsArticleRepository.GetAllAsync();
        }

        public async Task<NewsArticle?> GetNewsByIdAsync(int id)
        {
            return await _newsArticleRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<NewsArticle>> GetNewsByCategoryAsync(int categoryId)
        {
            return await _newsArticleRepository.GetNewsByCategoryAsync(categoryId);
        }

        public async Task AddNewsAsync(NewsArticle newsArticle)
        {
            await _newsArticleRepository.AddAsync(newsArticle);
        }

        public async Task UpdateNewsAsync(NewsArticle newsArticle)
        {
            await _newsArticleRepository.UpdateAsync(newsArticle);
        }

        public async Task DeleteNewsAsync(NewsArticle newsArticle)
        {
            await _newsArticleRepository.DeleteAsync(newsArticle);
        }
    }
}

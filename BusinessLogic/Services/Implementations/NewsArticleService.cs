using BusinessLayer.Services.Interfaces;
using DataLayer.Entities;
using DataLayer.Repositories.Implementations;
using DataLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Implementations
{
    public class NewsArticleService : INewsArticleService
    {
        private readonly INewsArticleIRepository _newsArticleRepository;

        public NewsArticleService(INewsArticleIRepository newsArticleRepository)
        {
            _newsArticleRepository = newsArticleRepository;
        }

        public async Task<IEnumerable<NewsArticle>> GetAllNewsArticlesAsync()
        {
            return await _newsArticleRepository.GetAllAsync();
        }

        public async Task<NewsArticle?> GetNewsArticleByIdAsync(int id)
        {
            return await _newsArticleRepository.GetByIdAsync(id);
        }

        public async Task<NewsArticle> CreateNewsArticleAsync(NewsArticle newsArticle)
        {
            return await _newsArticleRepository.CreateAsync(newsArticle);
        }

        public async Task<NewsArticle> UpdateNewsArticleAsync(NewsArticle newsArticle)
        {
            return await _newsArticleRepository.UpdateAsync(newsArticle);
        }

        public async Task<bool> DeleteNewsArticleAsync(int id)
        {
            var newsArticle = await _newsArticleRepository.GetByIdAsync(id);
            if (newsArticle == null)
            {
                return false;
            }

            await _newsArticleRepository.DeleteAsync(newsArticle);
            return true;
        }
    }
}

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
            if (string.IsNullOrWhiteSpace(newsArticle.NewsTitle))
                throw new ArgumentException("News title cannot be empty");

            if (string.IsNullOrWhiteSpace(newsArticle.Headline))
                throw new ArgumentException("Headline cannot be empty");

            if (string.IsNullOrWhiteSpace(newsArticle.NewsContent))
                throw new ArgumentException("Content cannot be empty");

            if (newsArticle.CategoryId <= 0)
                throw new ArgumentException("Invalid Category selected");

            newsArticle.CreatedDate = DateTime.Now;

            await _newsArticleRepository.AddAsync(newsArticle);
        }

        public async Task UpdateNewsAsync(NewsArticle newsArticle)
        {
            if (newsArticle.NewsArticleId <= 0)
                throw new ArgumentException("Invalid News Article ID");

            if (string.IsNullOrWhiteSpace(newsArticle.NewsTitle))
                throw new ArgumentException("News title cannot be empty");

            if (string.IsNullOrWhiteSpace(newsArticle.Headline))
                throw new ArgumentException("Headline cannot be empty");

            if (string.IsNullOrWhiteSpace(newsArticle.NewsContent))
                throw new ArgumentException("Content cannot be empty");

            newsArticle.ModifiedDate = DateTime.Now;

            await _newsArticleRepository.UpdateAsync(newsArticle);
        }

        public async Task DeleteNewsAsync(NewsArticle newsArticle)
        {
            if (newsArticle.NewsArticleId <= 0)
                throw new ArgumentException("Invalid News Article ID");

            await _newsArticleRepository.DeleteAsync(newsArticle);
        }
    }
}

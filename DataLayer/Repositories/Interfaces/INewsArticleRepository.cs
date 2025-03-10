using DataLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Interfaces
{
    public interface INewsArticleRepository : IRepository<NewsArticle>
    {
        Task<IEnumerable<NewsArticle>> GetNewsByCategoryAsync(int categoryId);
    }
}

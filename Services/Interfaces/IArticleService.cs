using NewsPaperAPI.Models;

namespace NewsPaperAPI.Services.ForAdminInterfaces
{
    public interface IArticleService
    {
        Task<Article> GetArticleById(int id);
        Task<Message> AddArticle(Article article);
        Task<Message> DeleteArticle(int id);
        Task<Message> UpdateArticle(int id, Article article);
    }
}

using Microsoft.AspNetCore.Mvc;
using NewsPaperAPI.Models;
using NewsPaperAPI.Services.ForAdminInterfaces;

namespace NewsPaperAPI.Services.ForAdminServices
{
    public class ArticleService:IArticleService
    {
        private readonly NewsPaperContext _context;
        public ArticleService(NewsPaperContext context)
        {
            _context = context;
        }

        public async Task<Article> GetArticleById(int id)
        {
            var result = _context.Articles.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<Message> AddArticle([FromBody] Article article)
        {
            article.IsDeleted = false;
            _context.Articles.Add(article);
            _context.SaveChanges();
            Message msg = new();
            msg.Response = true;
            msg.Msg = "Your Article Added";
            return msg;
        }

        public async Task<Message> UpdateArticle(int articleId, [FromBody] Article article)
        {
            Message msg = new();
            var result = _context.Articles.FirstOrDefault(x => x.Id == articleId);
            if (result == null)
            {
                msg.Response = false;
                msg.Msg = "You dont have access or there is no such article";
                return msg;
            }
            result.Title = article.Title;
            result.Info = article.Info;
            result.Image = article.Image;
            msg.Response = true;
            msg.Msg = "your article is updated";
            return msg;
        }

        public async Task<Message> DeleteArticle(int articleId)
        {
            Message msg = new();
            var result = _context.Articles.FirstOrDefault(x => x.Id == articleId);
            if (result == null)
            {
                msg.Response = false;
                msg.Msg = "Not Found";
                return msg;
            }
            result.IsDeleted = true;
            _context.SaveChanges();
            msg.Response = true;
            msg.Msg = "Article is Deleted";
            return msg;
        }
    }
}

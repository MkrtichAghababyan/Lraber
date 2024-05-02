using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPaperAPI.Models;
using NewsPaperAPI.Services.ForAdminInterfaces;

namespace NewsPaperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _context;
        public ArticleController(IArticleService context)
        {
            _context = context;
        }

        [HttpGet("GetArticleById/{id}")]
        public async Task<ActionResult<Article>> GetArticleById(int id)
        {
            Message msg = new();
            var result = _context.GetArticleById(id);
            if (result == null)
            {
                msg.Response = false;
                msg.Msg = "Article Not Found Or Dosn't Exist";
                return Ok(msg);
            }
            return Ok(result);
        }

        [HttpPost("AddArticle")]
        public async Task<ActionResult<Message>> AddArticle([FromBody] Article article)
        {
            var result = _context.AddArticle(article);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("UpdateArticle/{articleId}")]
        public async Task<ActionResult<Message>> UpdateArticle(int articleId, [FromBody] Article article)
        {
            var result = _context.UpdateArticle(articleId, article);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete("DeleteArticle/{articleId}")]
        public async Task<ActionResult<Message>> DeleteArticle(int articleId)
        {
            var result = _context.DeleteArticle(articleId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
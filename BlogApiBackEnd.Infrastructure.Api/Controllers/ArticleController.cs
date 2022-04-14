using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApiBackEnd.Domain.Contracts.DomainService;
using BlogApiBackEnd.Domain.Entities;
using BlogApiBackEnd.Infrastructure.Api.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Adapters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApiBackEnd.Infrastructure.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IDsArticle _dsArticle;
        private readonly ILogger<ArticleController> _logger;

        public ArticleController(IDsArticle dsArticle
            , ILogger<ArticleController> logger)
        {
            _dsArticle = dsArticle;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Article>> Get()
        {
            return await _dsArticle.Get();
        }

        [HttpGet("{id:int}")]
        public async Task<Article> Get(int id)
        {
            return (await _dsArticle.Get(x => x.Id == id)).FirstOrDefault();
        }

        [HttpPost]
        public async Task<ActionResult<Article>> Post(ArticleRequestDTO articleDTO)
        {
            var articleToInsert = new Article
            {
                Content = articleDTO.Content,
                Date = DateTime.Now,
                Title = articleDTO.Title
            };
            return await _dsArticle.Insert(articleToInsert);
        }

        [HttpPut]
        public ActionResult<Article> Put(Article article)
        {
            return _dsArticle.Modify(article);
        }

        [HttpDelete]
        public ActionResult Delete(Article article)
        {
            _dsArticle.Delete(article);
            return Ok();
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<Article>> JsonPatchForDynamic(int id, [FromBody] JsonPatchDocument patch)
        {
            var originaleArticle = (await _dsArticle.Get(b => b.Id == id)).FirstOrDefault();

            if (originaleArticle == null) return NotFound();

            patch.ApplyTo(originaleArticle, (IObjectAdapter)ModelState);

            return _dsArticle.Modify(originaleArticle);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BlogApiBackEnd.Domain.Contracts;
using BlogApiBackEnd.Domain.Contracts.DomainService;
using BlogApiBackEnd.Domain.Entities;
using Microsoft.Extensions.Logging;


namespace BlogApiBackEnd.DomainService
{
    public class DsArticle : IDsArticle
    {
        private readonly ILogger<DsArticle> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public DsArticle(IUnitOfWork unitOfWork
            , ILogger<DsArticle> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        public async Task<Article> Insert(Article article)
        {
            var articleToInsert = await _unitOfWork.Articles.Add(article);
            _unitOfWork.SaveChanges();

            return articleToInsert;
        }

        public Article Modify(Article article)
        {
            var articleToModify = _unitOfWork.Articles.Update(article);
            _unitOfWork.SaveChanges();

            return articleToModify;
        }

        public void Delete(Article article)
        {
            _unitOfWork.Articles.Delete(article);
            _unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<Article>> Get(Expression<Func<Article, bool>> @where = null)
        {
            if (where == null) return await _unitOfWork.Articles.GetAll();
            
            return await _unitOfWork.Articles.Get(where);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BlogApiBackEnd.Domain.Entities;
using System.Threading.Tasks;

namespace BlogApiBackEnd.Domain.Contracts.DomainService
{
    public interface IDSArticle
    {
        Task<Article> Insert(Article article);
        Article Modify(Article article);
        void Delete(Article article);
        Task<IEnumerable<Article>> Get(Expression<Func<Article, bool>> where = null);
    }
}
using BlogApiBackEnd.Domain.Contracts.Repositories;
using BlogApiBackEnd.Domain.Entities;
using BlogApiBackEnd.Infrastructure.EF.Data;

namespace BlogApiBackEnd.Infrastructure.EF.Repositories
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(BlogContext context) : base(context)
        {
            
        }
    }
}
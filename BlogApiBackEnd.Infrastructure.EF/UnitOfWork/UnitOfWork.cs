using System;
using BlogApiBackEnd.Domain.Contracts;
using BlogApiBackEnd.Domain.Contracts.Repositories;
using BlogApiBackEnd.Infrastructure.EF.Data;


namespace BlogApiBackEnd.Infrastructure.EF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly BlogContext _context;
        public IArticleRepository Articles { get; }

        public UnitOfWork(BlogContext context, IArticleRepository articleRepository)
        {
            _context = context;
            Articles = articleRepository;
        }

        
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
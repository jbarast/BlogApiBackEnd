using BlogApiBackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApiBackEnd.Infrastructure.EF.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            
        }
        
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder mOdelBuilder)
        {
            mOdelBuilder.Entity<Article>().ToTable(nameof(Article));
            
        }
    }
}
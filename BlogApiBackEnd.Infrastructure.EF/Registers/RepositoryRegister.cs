using BlogApiBackEnd.Domain.Contracts;
using BlogApiBackEnd.Domain.Contracts.Repositories;
using BlogApiBackEnd.Infrastructure.EF.Data;
using BlogApiBackEnd.Infrastructure.EF.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace BlogApiBackEnd.Infrastructure.EF.Registers
{
    public class RepositoryRegister
    {
        public static IServiceCollection AddRepository(IServiceCollection services, string connectionString)
        {
            // Repositories
            services.AddTransient<IArticleRepository, ArticleRepository>();
            
            // UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();

            // ConnectionString
            services.AddDbContext<BlogContext>(x => x.UseSqlServer(connectionString));

            return services;
        }
    }
}
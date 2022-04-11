using System;
using BlogApiBackEnd.Domain.Contracts.Repositories;

namespace BlogApiBackEnd.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository Articles { get; }


        void SaveChanges();
    }
}
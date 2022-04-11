using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogApiBackEnd.Domain.Contracts.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<List<T>> Get(Expression<Func<T, bool>> where);
        Task<T> Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
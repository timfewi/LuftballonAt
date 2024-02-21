using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LuftballonAt.Domain.Repository.Contracts
{
    public interface IRepository<T> where T : class
    {
        // Asynchrone Methoden
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        Task<T> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
        Task AddAsync(T entity);

        // Synchrone Methoden 
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}

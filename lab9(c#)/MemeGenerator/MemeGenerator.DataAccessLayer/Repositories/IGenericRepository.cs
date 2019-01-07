using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MemeGenerator.DataAccessLayer.Repositories
{
    public interface IGenericRepository<T>
    {
        void Add(T model);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        bool HasChanges();
        void Remove(T model);
        Task SaveAsync();
        IEnumerable<T> GetAllByCondition(Expression<Func<T, bool>> predicate);

        IEnumerable<T> Include(params Expression<Func<T, object>>[] includes);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGeneratorServer.DAL
{
     public interface IGenericRepository<T>
    {
        void Add(T model);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        bool HasChanges();
        void Remove(T model);
        Task SaveAsync();
    }
}

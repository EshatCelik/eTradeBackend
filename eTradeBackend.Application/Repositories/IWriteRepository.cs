using eTradeBackend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<T> AddRangeAsync(List<T> entity);
        bool Update(T entity);
        bool UpdateRange(List<T> entity);
        bool Remove(T entity);
        Task<T> RemoveAsync(string id);
        bool RemoveRange(List<T> entity);
        Task<int> SaveChange();
    }
}

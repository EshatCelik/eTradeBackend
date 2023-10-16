using eTradeBackend.Application.Repositories;
using eTradeBackend.Domain.Entities.Common;
using eTradeBackend.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly eTradeDbContext _dbContext;
        public WriteRepository(eTradeDbContext eTradeDbContext)
        {
            _dbContext = eTradeDbContext;
        }
        public DbSet<T> Table => _dbContext.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {

            EntityEntry<T> entry = await Table.AddAsync(entity);
            return entry != null;
        }

        public async Task<bool> AddRangeAsync(List<T> entity)
        {
            await Table.AddRangeAsync(entity);
            return true;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entry = Table.Remove(entity);
            return entry != null;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var findModel = await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            return Remove(findModel);

        }

        public bool RemoveRange(List<T> entity)
        {
            Table.RemoveRange(entity);
            return true;
        }

        public async Task<int> SaveChange() => await _dbContext.SaveChangesAsync();

        public bool Update(T entity)
        {
            EntityEntry<T> entityEntry = Table.Update(entity);
            return entityEntry != null;
        }

        public bool UpdateRange(List<T> entity)
        {
            Table.UpdateRange(entity);
            return true;
        }
    }
}

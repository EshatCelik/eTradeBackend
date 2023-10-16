using eTradeBackend.Application.Repositories;
using eTradeBackend.Domain.Entities.Common;
using eTradeBackend.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly eTradeDbContext _context;
        public ReadRepository(eTradeDbContext eTradeDbContext)
        {
            _context = eTradeDbContext;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool trackin = true)
        {
            var query = Table.AsQueryable();
            if (!trackin)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        }

        public Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query.FirstOrDefaultAsync(method);

        }

        public  IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if(!tracking)
                query = query.AsNoTracking();
            return query;
        }
    }
}

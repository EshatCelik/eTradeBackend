using eTradeBackend.Application.Repositories.OrderRepository;
using eTradeBackend.Domain.Entities;
using eTradeBackend.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Persistance.Repositories.OrderRepository
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(eTradeDbContext eTradeDbContext) : base(eTradeDbContext)
        {
        }
    }
}

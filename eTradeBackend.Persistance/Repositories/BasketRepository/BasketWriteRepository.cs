using eTradeBackend.Application.Repositories.Basket;
using eTradeBackend.Domain.Entities;
using eTradeBackend.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Persistance.Repositories.BasketItemRepository
{
    public class BasketWriteRepository : WriteRepository<Basket>, IBasketWriteRepository
    {
        public BasketWriteRepository(eTradeDbContext eTradeDbContext) : base(eTradeDbContext)
        {
        }
    }
}

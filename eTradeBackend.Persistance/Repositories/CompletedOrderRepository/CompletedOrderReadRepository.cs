using eTradeBackend.Application.Repositories.Basket;
using eTradeBackend.Application.Repositories.CompletedItem;
using eTradeBackend.Domain.Entities;
using eTradeBackend.Persistance.Contexts;
using eTradeBackend.Persistance.Repositories.BasketItemRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Persistance.Repositories.CompletedOrderRepository
{
    public class CompletedOrderReadRepository : ReadRepository<Domain.Entities.CompletedOrder>, ICompletedOrderReadRepository
    {
        public CompletedOrderReadRepository(eTradeDbContext eTradeDbContext) : base(eTradeDbContext)
        {
        }
    }
}

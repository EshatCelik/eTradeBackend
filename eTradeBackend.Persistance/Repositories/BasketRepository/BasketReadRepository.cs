using eTradeBackend.Application.Repositories.Basket;
using eTradeBackend.Domain.Entities;
using eTradeBackend.Persistance.Contexts;
using eTradeBackend.Persistance.Repositories.BasketItemRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Persistance.Repositories.BasketRepository
{
    public class BasketReadRepository : ReadRepository<Basket>, IBasketReadRepository
    {
        public BasketReadRepository(eTradeDbContext eTradeDbContext) : base(eTradeDbContext)
        {
        }
    }
}

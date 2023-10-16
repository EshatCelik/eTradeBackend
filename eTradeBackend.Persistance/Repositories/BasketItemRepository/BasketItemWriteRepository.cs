﻿using eTradeBackend.Application.Repositories.Basket;
using eTradeBackend.Domain.Entities;
using eTradeBackend.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Persistance.Repositories.BasketItemRepository
{
    public class BasketItemWriteRepository : WriteRepository<Basket>, IBasketWriteRepository
    {
        public BasketItemWriteRepository(eTradeDbContext eTradeDbContext) : base(eTradeDbContext)
        {
        }
    }
}

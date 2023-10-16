using eTradeBackend.Application.Repositories.CustomerRepository;
using eTradeBackend.Domain.Entities;
using eTradeBackend.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Persistance.Repositories.CustomerRepository
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(eTradeDbContext eTradeDbContext) : base(eTradeDbContext)
        {
        }
    }
}

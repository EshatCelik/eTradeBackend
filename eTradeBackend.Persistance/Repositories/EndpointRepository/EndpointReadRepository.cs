using eTradeBackend.Application.Repositories.EndpointRepository;
using eTradeBackend.Domain.Entities;
using eTradeBackend.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Persistance.Repositories.EndpointRepository
{
    public class EndpointReadRepository : ReadRepository<EndPoint>, IEndpointReadRepository
    {
        public EndpointReadRepository(eTradeDbContext eTradeDbContext) : base(eTradeDbContext)
        {
        }
    }
}

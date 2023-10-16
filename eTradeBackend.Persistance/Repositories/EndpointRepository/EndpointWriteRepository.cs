using eTradeBackend.Application.Repositories;
using eTradeBackend.Application.Repositories.EndpointRepository;
using eTradeBackend.Persistance.Contexts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Persistance.Repositories.EndpointRepository
{
    public class EndpointWriteRepository : WriteRepository<Domain.Entities.EndPoint>, IEndpointWriteRepository
    {
        public EndpointWriteRepository(eTradeDbContext eTradeDbContext) : base(eTradeDbContext)
        {
        }
    }
}

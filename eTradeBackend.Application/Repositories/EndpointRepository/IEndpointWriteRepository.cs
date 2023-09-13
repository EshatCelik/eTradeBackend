using eTradeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Repositories.EndpointRepository
{
    public interface IEndpointWriteRepository:IWriteRepository<Domain.Entities.EndPoint>
    {
    }
}

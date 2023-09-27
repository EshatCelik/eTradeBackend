using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Queries.Role.GetRoleById
{
    public class GetRoleByIdQueryRequest:IRequest<GetRoleByIdQueryResponse>
    {
        public string  RoleId { get; set; }
    }
}

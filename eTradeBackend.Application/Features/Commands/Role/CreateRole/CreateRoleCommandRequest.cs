using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.Role.CreateRole
{
    public class DeleteRoleCommandRequest:IRequest<DeleteRoleCommandResponse>
    {
        public string  RoleName { get; set; }
    }
}

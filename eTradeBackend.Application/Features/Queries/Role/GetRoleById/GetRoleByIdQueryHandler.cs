using eTradeBackend.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Queries.Role.GetRoleById
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQueryRequest, GetRoleByIdQueryResponse>
    {
        private readonly IRoleService _rolseService;

        public GetRoleByIdQueryHandler(IRoleService rolseService)
        {
            _rolseService = rolseService;
        }

        public async Task<GetRoleByIdQueryResponse> Handle(GetRoleByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data=await _rolseService.GetRoleByIdAsync(request.RoleId);
            return new()
            {
                Id = data.id,
                Name = data.name
            };
        }
    }
}

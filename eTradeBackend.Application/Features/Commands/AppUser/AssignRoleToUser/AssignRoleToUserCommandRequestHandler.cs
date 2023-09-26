using eTradeBackend.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.AppUser.AssignRoleToUser
{
    public class AssignRoleToUserCommandRequestHandler : IRequestHandler<AssignRoleToUserCommandRequest, AssignRoleToUserCommandResponse>
    {
        private readonly IUserService _userService;

        public AssignRoleToUserCommandRequestHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<AssignRoleToUserCommandResponse> Handle(AssignRoleToUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _userService.AssignRoleToUserAsync(request.UserId, request.Roles);
            return new() { };
        }
    }
}

﻿using eTradeBackend.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.Role.CreateRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, DeleteRoleCommandResponse>
    {
        private readonly IRoleService roleService;

        public DeleteRoleCommandHandler(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
           var result= await roleService.CreateRoleAsync(request.RoleName);
            return new()
            {
                Succeeded = result
            };
        }
    }
}

using eTradeBackend.Application.Repositories.EndpointRepository;
using eTradeBackend.Application.Repositories.MenuRepository;
using eTradeBackend.Application.Services;
using eTradeBackend.Application.Services.Configuration;
using eTradeBackend.Domain.Entities;
using eTradeBackend.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Persistance.Services
{
    public class AuthorizationEndpointService : IAuthorizationEndpointService
    {
        private readonly IMenuReadRepository _menuReadRepository;
        private readonly IMenuWriteRepository _menuWriteRepository;
        private readonly IEndpointWriteRepository _endpointWriteRepository;
        private readonly IEndpointReadRepository _endpointReadRepository;
        private readonly IApplicationService _applicationService;
        private readonly RoleManager<AppRole> _roleManager;

        public AuthorizationEndpointService(IMenuReadRepository menuReadRepository,
            IMenuWriteRepository menuWriteRepository,
            IEndpointWriteRepository endpointWriteRepository,
            IEndpointReadRepository endpointReadRepository,
            IApplicationService applicationService,
            RoleManager<AppRole> roleManager)
        {
            _menuReadRepository = menuReadRepository;
            _menuWriteRepository = menuWriteRepository;
            _endpointWriteRepository = endpointWriteRepository;
            _endpointReadRepository = endpointReadRepository;
            _applicationService = applicationService;
            _roleManager = roleManager;
        }
        public async Task AssingRoleEndpointAsync(string[] roles, string menu, string code, Type type)
        {
            Menu? _menu = await _menuReadRepository.GetSingleAsync(x => x.Name == menu);
            if (_menu == null)
            {
                _menu = new()
                {
                    Id = Guid.NewGuid(),
                    Name = menu
                };

                await _menuWriteRepository.AddAsync(_menu);
                await _menuWriteRepository.SaveChange();
            }
            EndPoint ? endpoint=await _endpointReadRepository.Table
                .Include(x=>x.Menu)
                .Include(x=>x.Roles)
                .FirstOrDefaultAsync(x=>x.Code==code && x.Menu.Name==menu);

            if (endpoint==null)
            {
                var action= _applicationService
                    .GetAuthorizationDefinitionEndpoints(type)
                    .FirstOrDefault(x=>x.Name==menu)?.Actions
                    .FirstOrDefault(x=>x.Code.Equals(code));

                endpoint = new()
                {

                    Id = Guid.NewGuid(),
                    Code = action.Code,
                    ActionType = action.ActionType,
                    HttpType = action.HttpType,
                    Definition = action.Definition,
                    Menu = _menu
                };

                await _endpointWriteRepository.AddAsync(endpoint);
                await _endpointWriteRepository.SaveChange();
            }

            foreach (var role in endpoint.Roles)
            {
                endpoint.Roles.Remove(role);
            }

            var appRoles=await _roleManager.Roles.Where(x=>roles.Contains(x.Id)).ToListAsync();
            foreach (var role in appRoles)
            {
                endpoint.Roles.Add(role);
            }

            await _endpointWriteRepository.SaveChange();
        }

        public async Task<List<string>?> GetRolesToEndpointAsync(string code, string menu)
        {
            EndPoint? endpoint=await _endpointReadRepository.Table
                .Include(x=>x.Roles)
                .Include(x=>x.Menu)
                .FirstOrDefaultAsync(x=>x.Code==code&&x.Menu.Name==menu);

            return endpoint?.Roles.Select(x=>x.Id).ToList();
               
        }
    }
}

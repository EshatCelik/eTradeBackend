using eTradeBackend.Application.CustomAttrubute;
using eTradeBackend.Application.DTOs.Configurations;
using eTradeBackend.Application.Enums;
using eTradeBackend.Application.Services.Configuration;
using eTradeBackend.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Infrastructure.Services.Configurations
{
    internal class ApplicationService : IApplicationService
    {
        public List<MenuDto> GetAuthorizationDefinitionEndpoints(Type type)
        {
            Assembly? assembly = Assembly.GetAssembly(type);

            var controllers = assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ControllerBase)));

            List<MenuDto> menus = new List<MenuDto>();
            if (controllers.Any())
            {
                foreach (var controller in controllers)
                {
                    var actions = controller.GetMethods().Where(x => x.IsDefined(typeof(AuthorizeDefinitionAttribute)));
                    if (actions.Any())
                    {
                        foreach (var action in actions)
                        {
                            var attrubutes = action.GetCustomAttributes(true);
                            if (attrubutes.Any())
                            {
                                MenuDto menu = null;

                                var authorizeDefinationAttribute = attrubutes.FirstOrDefault(a => a.GetType() == typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;
                                if (menus.Any(x => x.Name == authorizeDefinationAttribute.Menu))
                                {
                                    menu = new() { Name = authorizeDefinationAttribute.Menu };
                                    menus.Add(menu);
                                }
                                else
                                    menu = menus.FirstOrDefault(x => x.Name == authorizeDefinationAttribute.Menu);
                                ActionDto _action = new()
                                {
                                    ActionType = System.Enum.GetName(typeof(ActionType), authorizeDefinationAttribute.ActionType),
                                    Definition = authorizeDefinationAttribute.Defination
                                };
                                var httpAttubute = attrubutes.FirstOrDefault(x => x.GetType().IsAssignableTo(typeof(HttpMethodAttribute))) as HttpMethodAttribute;
                                if (httpAttubute != null)
                                    _action.HttpType = httpAttubute.HttpMethods.First();
                                else
                                    _action.HttpType = HttpMethods.Get;

                                _action.Code = $"{_action.HttpType}.{_action.ActionType}.{_action.Definition.Replace(" ", "")}";
                                menu.Actions.Add(_action);
                            }
                        }

                    }

                }
            }
            return menus;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Services
{
    public interface IAuthorizationEndpointService
    {
        Task AssingRoleEndpointAsync(string[] roles, string menu, string code, Type type);
        Task<List<string>> GetRolesToEndpointAsync(string code,string menu);
    }
}

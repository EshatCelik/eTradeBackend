using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Queries.AppUser.GetRolesToUser
{
    public class GetRolesToUserQueryResponse
    {
        public GetRolesToUserQueryResponse()
        {
            Roles = new List<string>();
        }
        public List<string> Roles { get; set; }
    }
}

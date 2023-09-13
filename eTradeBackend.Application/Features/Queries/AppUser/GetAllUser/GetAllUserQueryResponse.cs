using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Queries.AppUser.GetAllUser
{
    public class GetAllUserQueryResponse
    {
        public object Users { get; set; }
        public int TotalUserCount { get; set; }
    }
}

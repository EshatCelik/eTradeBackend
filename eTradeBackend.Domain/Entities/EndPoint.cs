using eTradeBackend.Domain.Entities.Common;
using eTradeBackend.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Domain.Entities
{
    public class EndPoint : BaseEntity
    {
        public EndPoint()
        {
            Roles = new HashSet<AppRole>();
        }

        public string ActionType { get; set; }
        public string HttpType { get; set; }
        public string Definition { get; set; }
        public string Code { get; set; }
        public Menu Menu { get; set; }
        public ICollection<AppRole> Roles { get; set; }
    }
}

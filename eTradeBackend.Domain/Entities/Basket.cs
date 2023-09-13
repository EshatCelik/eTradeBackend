using eTradeBackend.Domain.Entities.Common;
using eTradeBackend.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Domain.Entities
{
    public class Basket:BaseEntity
    {
        public string UserId { get; set; }
        public AppUser AppUser  { get; set; }
        public Order Order { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}

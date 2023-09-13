using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.DTOs.Order
{
    public class SingleOrder
    {
        public string Id { get ; set; }
        public string  OrderCode { get; set; }
        public object BasketItem { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}

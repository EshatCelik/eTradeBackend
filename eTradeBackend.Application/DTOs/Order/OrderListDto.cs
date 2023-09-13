using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.DTOs.Order
{
    public class OrderListDto
    {
        public int TotalCount { get; set; }
        public List<OrderDto> Orders { get; set; }
    }
    public class OrderDto
    {
        public string Id { get; set; }
        public string OrderCode { get; set; }
        public string UserName { get; set; }
        public float TotalPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Completed { get; set; }
    }
}

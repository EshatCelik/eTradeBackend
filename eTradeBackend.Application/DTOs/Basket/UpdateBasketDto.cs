using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.DTOs.Basket
{
    public class UpdateBasketDto
    {
        public string BasketItemId { get; set; }
        public int Quantity { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.Basket.AddItemToBasket
{
    public class AddItemToBasketCommandRequest:IRequest<AddItemToBasketCommandResponse>
    {
        public string Id { get; set; }
        public int  Quantity { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.Basket.UpdateItemToBasket
{
    public class UpdateItemToBasketCommandRequest:IRequest<UpdateItemToBasketCommandResponse>
    {
        public string BasketItemId { get; set; }
        public int Quantity { get; set; }
    }
}

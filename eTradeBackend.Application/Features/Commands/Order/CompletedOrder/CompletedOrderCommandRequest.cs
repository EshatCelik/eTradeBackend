using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.Order.CompletedOrder
{
    public class CompletedOrderCommandRequest:IRequest<CompletedOrderCommandResponse>
    {
        public string OrderId { get; set; }
    }
}

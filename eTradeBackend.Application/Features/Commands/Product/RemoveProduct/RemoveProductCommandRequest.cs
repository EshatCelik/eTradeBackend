using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.Product.RemoveProduct
{
    public class RemoveProductCommandRequest:IRequest<RemoveProductCommandResponse>
    {
        public string ProductId { get; set; }
    }
}

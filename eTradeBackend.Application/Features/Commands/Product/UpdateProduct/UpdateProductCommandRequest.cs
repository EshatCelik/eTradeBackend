using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
    }
}

using eTradeBackend.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Queries.Order.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQueryRequest, GetOrderByIdQueryResponse>
    {
        private readonly IOrderService _orderService;

        public GetOrderByIdQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<GetOrderByIdQueryResponse> Handle(GetOrderByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _orderService.GetOrderByIdAsync(request.OrderId);

            return new()
            {
                Id = result.Id,
                Address = result.Address,
                BasketItems = result.BasketItem,
                CreatedDate = result.CreateDate,
                Description = result.Description,
                OrderCode = result.OrderCode
            };
        }
    }
}

using eTradeBackend.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.Basket.AddItemToBasket
{
    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommandRequest, AddItemToBasketCommandResponse>
    {
        private readonly IBasketService _basketService;

        public AddItemToBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        async Task<AddItemToBasketCommandResponse> IRequestHandler<AddItemToBasketCommandRequest, AddItemToBasketCommandResponse>.Handle(AddItemToBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await _basketService.AddItemToBAsketAsync(new()
            {
                ProductId = request.Id,
                Quantity = request.Quantity
            });
            return new();
        }
    }
}

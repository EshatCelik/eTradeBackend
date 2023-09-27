using eTradeBackend.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.Basket.RemoveItemToBasket
{
    internal class RemoveItemToBasketCommandHandler : IRequestHandler<RemoveItemToBasketCommandRequest, RemoveItemToBasketCommandResponse>
    {
        private readonly IBasketService _basketService;

        public RemoveItemToBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<RemoveItemToBasketCommandResponse> Handle(RemoveItemToBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await _basketService.RemoveBasketItemAsync(request.BasketItemId);
            return new();
        }
    }
}
